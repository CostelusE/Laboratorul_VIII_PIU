using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Proiect
{
    public partial class Control_Search : UserControl
    {
        IStocareData adminPersoane = StocareFactory.GetAdministratorStocare();
        public Control_Search()
        {

            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCauta.BringToFront();
            lblNume1.BringToFront();
            lblPrenume1.BringToFront();
            txtPrenume1.BringToFront();
            txtNume1.BringToFront();
            label1.SendToBack();
            txtNume1.Enabled = true;
            txtPrenume1.Enabled = true;
            txtNume1.Clear();
            txtPrenume1.Clear();
            checkBoxGrup.SendToBack();
            checkBoxProvenienta.SendToBack();
            ResetareControale();
            checkBoxGrup.ForeColor = Color.Black;
            checkBoxProvenienta.ForeColor = Color.Black;



        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Agenda s = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);

            if (s != null)
            {

                btnModifica.BringToFront();
                txtNume1.Enabled = false;
                txtPrenume1.Enabled = false;
                btnModificaPers.BringToFront();
                checkBoxGrup.BringToFront();
                checkBoxProvenienta.BringToFront();
                ResetCuloareEtichete();

            }
            else if (txtNume1.Text != "" && txtPrenume1.Text != "")
            {


                label1.BringToFront();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
                checkBoxGrup.SendToBack();
                checkBoxProvenienta.SendToBack();
                ResetCuloareEtichete();
            }
            else
            {
                if (txtNume1.Text == "")
                    lblNume1.ForeColor = Color.Red;
                else
                    lblNume1.ForeColor = Color.Black;
                if (txtPrenume1.Text == "")
                    lblPrenume1.ForeColor = Color.Red;
                else
                    lblPrenume1.ForeColor = Color.Black;
            }

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            rtbNumeComplet.Clear();
            ArrayList AGENDA = adminPersoane.GetPersoane();
            foreach (Agenda pers in AGENDA)
            {
                rtbNumeComplet.AppendText(pers.Nume_Complet());
                rtbNumeComplet.AppendText(" --> ");
                rtbNumeComplet.AppendText(pers.Varsta());
                rtbNumeComplet.AppendText(" ani");
                rtbNumeComplet.SelectionTabs = new int[] { 5 };
                rtbNumeComplet.AppendText(Environment.NewLine);
            }
        }

        private void button_Modifica(object sender, EventArgs e)
        {
           

        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if(checkBoxGrup.Checked==true && checkBoxProvenienta.Checked==true)
            Panel_Modifica.BringToFront();
            else
               if (checkBoxGrup.Checked == false && checkBoxProvenienta.Checked == true)
             Panel_Modifica2.BringToFront();
            else
                if (checkBoxGrup.Checked == true && checkBoxProvenienta.Checked == false)
                Panel_Modifica3.BringToFront();
            else
            {
                checkBoxGrup.ForeColor = Color.Red;
                checkBoxProvenienta.ForeColor = Color.Red;
            }
        

        }

        private void button4_Click(object sender, EventArgs e)
        {
            btnModificaPers.SendToBack();
            txtNume1.Enabled = true;
            txtPrenume1.Enabled = true;
            btnModifica.SendToBack();
            checkBoxGrup.SendToBack();
            checkBoxProvenienta.SendToBack();


        }

        private void lblSuccesAdaugare_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private Provenienta GetProvenientaSelectata()
        {
            if (rbAnglia.Checked)
                return Provenienta.Anglia;
            if(rbRomania.Checked)
                return Provenienta.Romania;
            if(rbGermania.Checked)
                return Provenienta.Germania;
            if(rbOlanda.Checked)
                return Provenienta.Olanda;
            if(rbItalia.Checked)
                return Provenienta.Italia;
            if(rbSpania.Checked)
                return Provenienta.Spania;
            return Provenienta.Romania;
        }

        private Provenienta GetProvenientaSelectata2()
        {
            if (rbAnglia2.Checked)
                return Provenienta.Anglia;
            if (rbRomania2.Checked)
                return Provenienta.Romania;
            if (rbGermania2.Checked)
                return Provenienta.Germania;
            if (rbOlanda2.Checked)
                return Provenienta.Olanda;
            if (rbItalia2.Checked)
                return Provenienta.Italia;
            if (rbSpania2.Checked)
                return Provenienta.Spania;
            return Provenienta.Romania;
        }

        private Grup GetGrupSelectat()
        {
            if (rbScoala.Checked)
                return Grup.Scoala;
            if (rbServici.Checked)
                return Grup.Serviciu;
            if (rbPrieteni.Checked)
                return Grup.Prieteni;
            if (rbFamilie.Checked)
                return Grup.Familie;
            return Grup.Familie;
        }

        private Grup GetGrupSelectat2()
        {
            if (rbScoala2.Checked)
                return Grup.Scoala;
            if (rbServici2.Checked)
                return Grup.Serviciu;
            if (rbPrieteni2.Checked)
                return Grup.Prieteni;
            if (rbFamilie2.Checked)
                return Grup.Familie;
            return Grup.Familie;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Validare() == "adevarat")
            {
                Agenda persoana = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);
                persoana.provenienta = GetProvenientaSelectata();
                persoana.grup = GetGrupSelectat();
                adminPersoane.UpdateStudent(persoana);
                Panel_Modifica.SendToBack();
                checkBoxGrup.SendToBack();
                checkBoxProvenienta.SendToBack();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
                label1.SendToBack();
                btnModifica.SendToBack();
                btnModificaPers.SendToBack();
                labelProvenienta.ForeColor = Color.Black;
                labelGrup.ForeColor = Color.Black;
            }
            else
                if(Validare()=="false")
                    {
                labelGrup.ForeColor = Color.Red;     
                labelProvenienta.ForeColor = Color.Red;
                     }
            else
                    if (Validare() == "grup")
            {
                labelGrup.ForeColor = Color.Red;
                labelProvenienta.ForeColor = Color.Black;
            }
            else
            {
                labelGrup.ForeColor = Color.Black;
                labelProvenienta.ForeColor = Color.Red;

            }



        }
        private void ResetCuloareEtichete()
        {
            lblPrenume1.ForeColor = Color.Black;
            lblNume1.ForeColor = Color.Black;
        }
        private string Validare()
        {
            
           int provenientaSelecatata = 0;
            foreach (var control in gbProvenienta.Controls)
            {
                RadioButton rdb = null;
                try
                {
                    rdb = (RadioButton)control;
                }
                catch { }

                if (rdb != null && rdb.Checked == true)
                    provenientaSelecatata = 1;
            }
                int grupSelecatat = 0;
                foreach (var control1 in gbGrup.Controls)
                {
                    RadioButton rdb1 = null;
                    try
                    {
                        rdb1 = (RadioButton)control1;
                    }
                    catch { }

                    if (rdb1 != null && rdb1.Checked == true)
                        grupSelecatat = 1;
                }
                if (grupSelecatat == 1 && provenientaSelecatata == 1)
                    return "adevarat";
                else
                    if (grupSelecatat == 0 && provenientaSelecatata == 1)
                    return "grup";
                else
                    if (grupSelecatat == 1 && provenientaSelecatata == 0)
                    return "provenienta";
                else
                    return "fals";
             
            
        }

        private void panel_Modifica2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rbPrieteni_CheckedChanged(object sender, EventArgs e)
        {

        }

 
        private void ResetareControale()
        {
            rbAnglia.Checked = false;
            rbAnglia2.Checked = false;
            rbRomania.Checked = false;
            rbRomania2.Checked = false;
            rbSpania.Checked = false;
            rbSpania2.Checked = false;
            rbGermania.Checked = false;
            rbGermania2.Checked = false;
            rbItalia.Checked = false;
            rbItalia2.Checked = false;
            rbOlanda.Checked = false;
            rbOlanda2.Checked = false;
            rbPrieteni.Checked = false;
            rbPrieteni2.Checked = false;
            rbScoala.Checked = false;
            rbScoala2.Checked = false;
            rbServici.Checked = false;
            rbServici2.Checked = false;
            rbFamilie.Checked = false;
            rbFamilie2.Checked = false;
            checkBoxGrup.Checked = false;
            checkBoxProvenienta.Checked = false;

        }

        private void buttonFinalizare2_Click_1(object sender, EventArgs e)
        {
            int provenientaSelecatata = 0;
            foreach (var control in groupBox2.Controls)
            {
                RadioButton rdb = null;
                try
                {
                    rdb = (RadioButton)control;
                }
                catch { }

                if (rdb != null && rdb.Checked == true)
                    provenientaSelecatata = 1;
            }
            if (provenientaSelecatata == 1)
            {
                Agenda persoana2 = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);
                persoana2.provenienta = GetProvenientaSelectata2();
                adminPersoane.UpdateStudent(persoana2);
                Panel_Modifica2.SendToBack();
                checkBoxGrup.SendToBack();
                checkBoxProvenienta.SendToBack();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
                label1.SendToBack();
                btnModifica.SendToBack();
                btnModificaPers.SendToBack();
                ResetareControale();
                labelProvenienta2.ForeColor = Color.Black;
            }
            else
                labelProvenienta2.ForeColor = Color.Red;
        }

        private void buttonFinalizare3_Click_1(object sender, EventArgs e)
        {


            int grupSelecatat = 0;
            foreach (var control1 in groupBox1.Controls)
            {
                RadioButton rdb1 = null;
                try
                {
                    rdb1 = (RadioButton)control1;
                }
                catch { }

                if (rdb1 != null && rdb1.Checked == true)
                    grupSelecatat = 1;
            }
            if (grupSelecatat == 1)
            {
                Agenda persoana1 = adminPersoane.GetPersoana(txtNume1.Text, txtPrenume1.Text);
                persoana1.grup = GetGrupSelectat2();
                adminPersoane.UpdateStudent(persoana1);
                Panel_Modifica3.SendToBack();
                checkBoxGrup.SendToBack();
                checkBoxProvenienta.SendToBack();
                btnCauta.SendToBack();
                lblNume1.SendToBack();
                lblPrenume1.SendToBack();
                txtPrenume1.SendToBack();
                txtNume1.SendToBack();
                label1.SendToBack();
                btnModifica.SendToBack();
                btnModificaPers.SendToBack();
                ResetareControale();
                labelGrup2.ForeColor = Color.Black;
            }
            else
                labelGrup2.ForeColor = Color.Red;
        }
    }
}
