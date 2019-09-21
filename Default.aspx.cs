using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCompi
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            if (fuArchivo.PostedFile != null && fuArchivo.PostedFile.ContentLength > 0)
            {

                string fileName = Path.GetFileName(fuArchivo.PostedFile.FileName);
                string folder = Server.MapPath("~/files/");
                Directory.CreateDirectory(folder);
                fuArchivo.PostedFile.SaveAs(Path.Combine(folder, fileName));
                
                String template = File.ReadAllText(Server.MapPath("~/files/") + fileName);
                //Response.Write(template + "\n");
                Console.WriteLine(template);
                int posF = template.IndexOf("F");
                int posI = template.IndexOf("i");
                int posA = template.IndexOf("A");
                int posW = template.IndexOf("w");
                String Q = template.Substring(0, posF);
                String F = template.Substring(posF, posI - posF);
                String I = template.Substring(posI, posA - posI);
                String A = template.Substring(posA, posW - posA);
                String W = template.Substring(posW, template.Length - posW);

                tbTXT.Text += Q + "\r\n";
                tbTXT.Text += F + "\r\n";
                tbTXT.Text += I + "\r\n";
                tbTXT.Text += A + "\r\n";
                tbTXT.Text += W + "\r\n";

                //Q
                int inicio = Q.IndexOf("{") + 1;
                int fin = Q.IndexOf("}");
                Q = Q.Substring(inicio, fin - inicio);
                Q = Q.Replace(",", string.Empty);
                char[] caQ = Q.ToCharArray();
                for (int i = 0; i < caQ.Length; i++) {
                    tbQ.Text += caQ[i] + "\r\n";
                }
                //F
                inicio = F.IndexOf("{") + 1;
                fin = F.IndexOf("}");
                F = F.Substring(inicio, fin - inicio);
                F = F.Replace(",", string.Empty);
                char[] caF = F.ToCharArray();
                for (int i = 0; i < caF.Length; i++)
                {
                    tbF.Text += caF[i] + "\r\n";
                }

                //A
                inicio = A.IndexOf("{") + 1;
                fin = A.IndexOf("}");
                A = A.Substring(inicio, fin - inicio);
                A = A.Replace(",", string.Empty);
                char[] caA = A.ToCharArray();
                for(int i = 0; i < caA.Length; i++)
                {
                    tbA.Text += caA[i] + "\r\n";
                }

                //W
                inicio = W.IndexOf("{") + 1;
                fin = W.IndexOf("}");
                W = W.Substring(inicio, fin - inicio);
                char[] separator = {'(',')'};
                String[] WList = W.Split(separator);
                var temp = new List<string>();
                foreach (var s in WList)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        if (!s.Equals(","))
                        {
                            temp.Add(s);
                        }
                    }
                }
                WList = temp.ToArray();

                DataTable dt = new DataTable();
                dt.Columns.Add("N");
                for (int i = 0; i < caF.Length; i++)
                {
                    dt.Columns.Add(caF[i].ToString());
                }
                if (W.Contains("e")) {
                    dt.Columns.Add("e");
                }

                for (int i = 0; i < WList.Length; i++)
                {
                    char[] coma = {','};
                    String[] wLinea = WList[i].Split(coma);
                    String de = wLinea[0];
                    String valor = wLinea[1];
                    String a = wLinea[2];

                    //validar si ya existe "de"
                    bool bandera = false;
                    foreach (DataRow row in dt.Rows)
                    {
                        if (de.Equals(row["N"])) {
                            bandera = true;
                            row[valor] = a;
                        }
                    }
                    if (bandera == false)
                    {
                        DataRow dr = dt.NewRow();
                        dr["N"] = de;
                        dr[valor] = a;
                        dt.Rows.Add(dr);
                    }
                }
                gvAFN.DataSource = dt;
                gvAFN.DataBind();
            }
        }
    }
}