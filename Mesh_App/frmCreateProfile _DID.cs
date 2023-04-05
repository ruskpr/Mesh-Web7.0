/*
Technitium Mesh
Copyright (C) 2019  Shreyas Zare (shreyas@technitium.com)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/

using Mesh_Core;
using Mesh_Core.DIDComm;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;
using TechnitiumLibrary.Net.Proxy;
using TechnitiumLibrary.Security.Cryptography;

namespace Mesh_App
{
    public partial class frmCreateProfile_DID : Form
    {
        #region variables

        DIDUser? _newUser = null;

        #endregion

        #region constructor

        public frmCreateProfile_DID()
        {
            InitializeComponent();

            btnBack.DialogResult = DialogResult.None;
        }

        #endregion

        #region form code

        private void rbImportRSA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkEnableProxy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            #region validate form

            if (string.IsNullOrEmpty(txtProfileDisplayName.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid name.", "Name Missing!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProfileDisplayName.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtProfilePassword.Text))
            {
                MessageBox.Show("Please enter a profile password.", "Profile Password Missing!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProfilePassword.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please confirm profile password.", "Confirm Password Missing!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtConfirmPassword.Focus();
                return;
            }

            if (txtConfirmPassword.Text != txtProfilePassword.Text)
            {
                txtProfilePassword.Text = "";
                txtConfirmPassword.Text = "";
                MessageBox.Show("Profile password doesn't match with confirm profile password. Please enter both passwords again.", "Password Mismatch!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtProfilePassword.Focus();
                return;
            }

            //DIDUser.Create(txtProfileDisplayName.Text, txtProfilePassword.Text);

            #endregion

            this.DialogResult = DialogResult.OK;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to close this window?", "Close Window?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private void frmCreateProfile_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you sure to close this window?", "Close Window?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.DialogResult = DialogResult.Cancel;
                else
                    e.Cancel = true;
            }
        }

        private void btnImportKey_Click(object sender, EventArgs e)
        {
            // create open file dialog to get a single file to import
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select DID Key File to Import";
            ofd.Filter = "DID Key Files (*.profile.json)|*.profile.json|All Files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // import key
                    _newUser = DIDUser.Import(ofd.FileName, true);
                    // display key info
                    txtProfileDisplayName.Text = _newUser.Name;
                    txtProfilePassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtProfilePassword.Enabled = false;
                    txtConfirmPassword.Enabled = false;
                    btnImportKey.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while importing key file. " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region properties

        public string ProfileDisplayName
        { get { return txtProfileDisplayName.Text.Trim(); } }

        public string ProfilePassword
        { get { return txtProfilePassword.Text; } }

        #endregion
    }
}
