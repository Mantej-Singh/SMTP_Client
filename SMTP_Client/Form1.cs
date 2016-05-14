using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;//library i used

namespace SMTP_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsend_Click(object sender, EventArgs e)
        {
            if (textBoxSendTo.Text == "")
            {
                MessageBox.Show("Please enter the Recipient's Name");
            }

                  try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(textBoxSendTo.Text);
                //mail.To.Add("mdmantejsingh@gmail.com");
                mail.From = new MailAddress(txtgid.Text);
                mail.Subject = textBoxSubject.Text;
                string Body = richTextBoxMessage.Text;
                mail.Body = Body;
                if (textBoxAttachment.Text != "")
                {
                    mail.Attachments.Add(new Attachment(textBoxAttachment.Text));
                }
                mail.IsBodyHtml = true;


                SmtpClient smtp = new SmtpClient("localhost", 587);
                smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address  
                smtp.Credentials = new System.Net.NetworkCredential
                     (txtgid.Text, txtpwd.Text);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(mail);
                MessageBox.Show("Message delivered successfully!!!", "Yaaayyyy...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Message could not be sent.\nThe following error was returned:\n'" + ex.Message + "'", "SMTP Email Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
      
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBoxAttachment.Text = openFileDialog1.FileName;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            txtgid.Clear();
            txtpwd.Clear();
            textBoxSendTo.Clear();
            textBoxSubject.Clear();
            textBoxAttachment.Clear();
            richTextBoxMessage.Clear();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                Font font = fontDialog1.Font;
                this.richTextBoxMessage.Font = font;
            }
        }

        private void textBoxSendTo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
