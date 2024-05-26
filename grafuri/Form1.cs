namespace grafuri
{
    public partial class Form1 : Form
    {
        private List<PointF> noduri = new List<PointF>();
        private List<Tuple<int, int>> muchii = new List<Tuple<int, int>>();
        private Dictionary<int, List<int>> listaAdiacenta = new Dictionary<int, List<int>>();
        private int raza = 30;
        private int numarNoduri = 0;
        public Form1()
        {
            InitializeComponent();
            panelGrafic.Paint += panelGrafic_Paint;
            panelGrafic.MouseClick += panelGrafic_MouseClick;
        }

        private void btnIncarcaGraf_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogDeschidere = new OpenFileDialog();
            if (dialogDeschidere.ShowDialog() == DialogResult.OK)
            {
                IncarcaGraf(dialogDeschidere.FileName);
                GenereazaCoordonateNoduri();
                panelGrafic.Invalidate();
            }
        }
        private void IncarcaGraf(string caleFisier)
        {
            noduri.Clear();
            muchii.Clear();
            listaAdiacenta.Clear();
            numarNoduri = 0;

            using (StreamReader sr = new StreamReader(caleFisier))
            {
                int numarTotalNoduri = int.Parse(sr.ReadLine());
                numarNoduri = numarTotalNoduri;

                for (int i = 0; i < numarTotalNoduri; i++)
                {
                    listaAdiacenta[i] = new List<int>();
                }

                while (!sr.EndOfStream)
                {
                    string[] muchieNoduri = sr.ReadLine().Split(' ');
                    int nod1 = int.Parse(muchieNoduri[0]);
                    int nod2 = int.Parse(muchieNoduri[1]);
                    muchii.Add(Tuple.Create(nod1, nod2));
                    listaAdiacenta[nod1].Add(nod2);
                    listaAdiacenta[nod2].Add(nod1);
                }
            }
        }
        private void GenereazaCoordonateNoduri()
        {
            float centruX = panelGrafic.Width / 2;
            float centruY = panelGrafic.Height / 2;
            float razaCerc = Math.Min(panelGrafic.Width, panelGrafic.Height) / 3;
            float unghiPas = 360f / numarNoduri;

            for (int i = 0; i < numarNoduri; i++)
            {
                float unghi = unghiPas * i;
                float x = centruX + razaCerc * (float)Math.Cos(unghi * Math.PI / 180);
                float y = centruY + razaCerc * (float)Math.Sin(unghi * Math.PI / 180);
                noduri.Add(new PointF(x, y));
            }
        }

        private void panelGrafic_Paint(object sender, PaintEventArgs e)
        {
            Graphics grafica = e.Graphics;
            grafica.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            foreach (var muchie in muchii)
            {
                PointF p1 = noduri[muchie.Item1];
                PointF p2 = noduri[muchie.Item2];
                grafica.DrawLine(Pens.Black, p1, p2);
            }

            for (int i = 0; i < noduri.Count; i++)
            {
                PointF nod = noduri[i];
                RectangleF dreptunghi = new RectangleF(nod.X - raza / 2, nod.Y - raza / 2, raza, raza);
                grafica.FillEllipse(Brushes.Blue, dreptunghi);
                grafica.DrawEllipse(Pens.Black, dreptunghi);

                string textNod = i.ToString();
                SizeF textDimensiune = grafica.MeasureString(textNod, this.Font);
                PointF pozitieText = new PointF(nod.X - textDimensiune.Width / 2, nod.Y - textDimensiune.Height / 2);
                grafica.DrawString(textNod, this.Font, Brushes.White, pozitieText);
            }
        }
        private void panelGrafic_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < noduri.Count; i++)
            {
                PointF nod = noduri[i];
                if (Math.Sqrt(Math.Pow(e.X - nod.X, 2) + Math.Pow(e.Y - nod.Y, 2)) <= raza / 2)
                {
                    StartDFS(i);
                    break;
                }
            }
        }
        private void StartDFS(int nodStart)
        {
            Stack<int> stiva = new Stack<int>();
            HashSet<int> vizitat = new HashSet<int>();
            stiva.Push(nodStart);
            vizitat.Add(nodStart);

            Graphics grafica = panelGrafic.CreateGraphics();
            PointF nodStartCoord = noduri[nodStart];
            grafica.FillEllipse(Brushes.Red, nodStartCoord.X - raza / 2, nodStartCoord.Y - raza / 2, raza, raza);

            while (stiva.Count > 0)
            {
                int curent = stiva.Pop();
                foreach (var vecin in listaAdiacenta[curent])
                {
                    if (!vizitat.Contains(vecin))
                    {
                        stiva.Push(vecin);
                        vizitat.Add(vecin);
                        PointF coordCurent = noduri[curent];
                        PointF coordVecin = noduri[vecin];
                        grafica.DrawLine(new Pen(Color.Red, 2), coordCurent, coordVecin);
                        grafica.FillEllipse(Brushes.Red, coordVecin.X - raza / 2, coordVecin.Y - raza / 2, raza, raza);
                        System.Threading.Thread.Sleep(500); 
                    }
                }
            }
        }
        }
}
