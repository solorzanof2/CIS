﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CIS.Presentation.UI.WindowsForms
{
    public partial class frmNew_User : Form
    {
        public frmNew_User()
        {
            InitializeComponent();
        }
        //declaration of variables to be used within the program
        string connectionString;
        SqlConnection con;
        SqlCommand cmd;

        private void New_User_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(CIS.Presentation.UI.WindowsForms.Properties.Settings.Default.LocalDB);
            con.Open();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //inserting data from the textbox controls into the MySql database (saving users' login details)
            cmd = con.CreateCommand();
            cmd.CommandText = "INSERT INTO Logins(firstName, lastName, Username, Password, Module_Access)VALUES(@firstname, @lastname, @username, @password, @module_access)";
            cmd.Parameters.AddWithValue("@firstname", txtFName.Text);
            cmd.Parameters.AddWithValue("@lastname", txtLName.Text);
            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
            cmd.Parameters.AddWithValue("@password", txtPassword.Text);
            cmd.Parameters.AddWithValue("@module_access", txtProfile.Text);


            cmd.ExecuteNonQuery();

            MessageBox.Show("New User Created");
            this.Close();


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //close this module
            this.Close();

        }

    }
}
