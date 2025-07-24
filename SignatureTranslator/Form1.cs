namespace SignatureTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<String> signatureTranslate(string signature, string mask)
        {
            List<string> res = new List<string>();

            int sId = 0;

            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == '?')
                {
                    res.Add("-1");
                    sId += 4;
                }
                else
                {
                    string element = "";
                    for (int j = 0; j < 4; j++)
                    {
                        if (signature[sId + j] == 92)
                        {
                            element += "0";
                        }
                        else
                        {
                            element += signature[sId + j];
                        }
                    }
                    res.Add(element);
                    sId += 4;
                }
            }

            return res;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sgn = textBox1.Text;
            string msk = textBox2.Text;

            List<string> signature = signatureTranslate(sgn, msk);

            textBox3.Text = "";

            for (int i = 0; i < signature.Count; i++)
            {
                textBox3.Text += signature[i];
                if (i != signature.Count - 1)
                {
                    textBox3.Text += ",";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
                Clipboard.SetText(textBox3.Text);
        }
    }
}
