using System;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace RichEditSmartQuotes {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void richEditControl1_AutoCorrect(object sender, AutoCorrectEventArgs e) {
            AutoCorrectInfo info = e.AutoCorrectInfo;
            e.AutoCorrectInfo = null;
            int count = 0;

            if (info.Text.Length <= 0)
                return;

            if (info.Text[0] == '"') {
                string replace = "“";

                for (; ; ) {
                    if (!info.DecrementStartPosition())
                        break;

                    count++;

                    if (info.Text[0] == '”')
                        break;

                    if (info.Text[0] == '“') {
                        replace = "”";
                        break;
                    }
                }

                info.ReplaceWith = replace;
                e.AutoCorrectInfo = info;
            }
            else if (info.Text[0] == '\'') {
                string replace = "‘";

                for (; ; ) {
                    if (!info.DecrementStartPosition())
                        break;

                    count++;

                    if (info.Text[0] == '’')
                        break;

                    if (info.Text[0] == '‘') {
                        replace = "’";
                        break;
                    }
                }

                info.ReplaceWith = replace;
                e.AutoCorrectInfo = info;
            }

            for (int i = 0; i < count; i++)
                info.IncrementStartPosition();
        }
    }
}