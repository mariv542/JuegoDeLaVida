using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int longitud = 25;
        private int longitudPixel = 15;
        private int[,] celulas;
        private System.Windows.Forms.Timer timer;
        private int generacion = 0;
        private System.Windows.Forms.PictureBox pbGrid;
        public Form1()
        {
            InitializeComponent();
            celulas = new int[longitud, longitud];
        }
        /*
         * Nota: en un futuro con tiempo quiero hacerlo de nuevo todo pero mucho mas optimizado
         */

        // evento que se encarga de abrir el txt 
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            //se abre el txt
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //se encarga de leer y almacenar las lineas
                string[] lines = File.ReadAllLines(openFileDialog.FileName);

                // Verifica que el archivo tenga 25 líneas
                if (lines.Length != 25)
                {
                    //si no tiene el rango especifico te va a mandar un mensaje de advertencia
                    MessageBox.Show("El archivo debe tener 25 líneas.");
                    return;
                }

                //recorre el archivo y verifica que contenga 25 valores
                for (int i = 0; i < 25; i++)
                {
                    //aqui los almacena y los separa
                    string[] values = lines[i].Split(',');

                    // Verifica que cada línea tenga 25 valores
                    if (values.Length != 25)
                    {
                        //si no tiene el rango especifico manda mensaje de advertencia
                        MessageBox.Show($"La línea {i + 1} debe tener 25 valores separados por comas.");
                        return;
                    }

                    //ahora los agrega los datos a la matriz
                    for (int j = 0; j < 25; j++)
                    {
                        // Trim() elimina espacios en blanco
                        celulas[i, j] = int.Parse(values[j].Trim()); 
                    }
                }
                //fubcion para representar la matriz
                DibujarGrid();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void labelNumeroSimulacion_Click(object sender, EventArgs e)
        {

        }

        //evento que se encarga de generar las
        //diferenten generaciones de vida cada 0.5 segundos
        private void btnInciarSimulacion_Click(object sender, EventArgs e)
        {
            //libreria timer para windows form
            timer = new System.Windows.Forms.Timer();
            // 0.5 segundos por generación
            timer.Interval = 500; 
            // funcion lamba para llamar a la funcion de avanzar generacion 
            // y genere evento cada cierto tiempo
            timer.Tick += (s, ev) => AvanzarGeneracion();
            timer.Start();
        }

        // funcion que se encarga de comprar si el timer es distinto a null 
        // se va a encargar de cancelar el avance del tiempo y de las generaciones
        private void btnDetenerSimulacion_Click(object sender, EventArgs e)
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }
        }


        //funcion que se encarga de dibujar la matrix en el picture box
        private void DibujarGrid()
        {
            // el cual se encarga de usar bitmap y generar un nuevo bitmap
            // para cada generacion y lo instancia en el componente grafico pinture box
            // tanto ancho como alto
            Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            // recorre x, y para verificar cuales son las casillas que necesitan ser pintadas
            for (int x = 0; x < longitud; x++)
            {
                for (int y = 0; y < longitud; y++)
                {
                        Brush brush;
                        // usando la libreria brush para pintar el cuadro 
                        // en el color selecionado
                        if (celulas[x, y] == 1)
                        {
                            brush = Brushes.Pink;
                        }
                        else
                        {
                            brush = Brushes.White;
                            
                        }
                        // se encarga de generar el rectangulo multiplicando por los valores predefinidos para que todos tengan el mismo espacio
                        g.FillRectangle(brush, x * longitudPixel, y * longitudPixel, longitudPixel, longitudPixel);
                        g.DrawRectangle(Pens.Purple, x * longitudPixel, y * longitudPixel, longitudPixel, longitudPixel);
                }
            }
            // despues se encarga de genrar la imagen
            pictureBox.Image = bmp;

        }
        

        // funcion que se encarga de avanzar las generaciones
        private void AvanzarGeneracion()
        {
            // para que no halla errores al avanzar la generacion
            // se genera una nueva matriz para ir comprando los valores
            int[,] nuevoGrid = new int[25, 25];

            // se encarga de recorrer x, y usando la misma estructura
            for (int x = 0; x < 25; x++)
            {
                for (int y = 0; y < 25; y++)
                {
                    int vecinosVivos = ContarVecinosVivos(x, y);
                    // se agrega una nueva variable para saber la cantidad de vecinos
                    // y contarlos segun filas y columnas
                    // antes de generar una nueva generacion
                    if (celulas[x, y] == 1)
                    {
                        // aqui estan las condicionales del juego de la vida el cual deciden si 
                        // vive o muere
                        nuevoGrid[x, y] = (vecinosVivos == 2 || vecinosVivos == 3) ? 1 : 0;
                    }
                    else
                    {
                        nuevoGrid[x, y] = (vecinosVivos == 3) ? 1 : 0;
                    }
                }
            }
            // despues la matriz se le asigna el nuevo grid
            celulas = nuevoGrid;
            // al contador de la generaciones pasadas se le suma 1
            generacion++;
            // despues se llama a el componente grafico para que cambie el texto 
            // para que refleje la generacion actual
            labelContadorGeneracion.Text = $"({generacion})";
            // despues se pinta la nueva matriz
            DibujarGrid();
        }

        // funcione que se encarga de contar cuantos vecinos 
        // vivos tiene segun el eje x o y donde este parado
        private int ContarVecinosVivos(int fila, int col)
        {
            // se crea una nueva variable que se encarga
            // de contar cuantos en fila (vecinos) y
            // de contar cuantos en columna (vecinos) 
            // estan vivos
            int count = 0;
            // se recorre el eje x 
            for (int x = -1; x <= 1; x++)
            {
                // se recorre el eje y
                for (int y = -1; y <= 1; y++)
                {
                    // si despues de recorrer los valores no aumentaron se omite
                    if (x == 0 && y == 0) continue;

                    // despues se agregan a una nueva variable 
                    // para contar la cantidad de vecions que tiene 
                    // cada celula el cual va a definir su destino
                    int vecinoFila = fila + x;
                    int vecinoCol = col + y;

                    // aqui se realiza la comparacion
                    if (vecinoFila >= 0 && vecinoFila < 25 && vecinoCol >= 0 && vecinoCol < 25)
                    {
                        // y aqui se cuanta la cantidad de vecinos segun la celula
                        count += celulas[vecinoFila, vecinoCol];
                    }
                }
            }
            // despues retorna la cantidad de vecinos
            return count;
        }
    }
}
