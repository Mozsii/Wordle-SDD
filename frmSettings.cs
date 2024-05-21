﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmSettings : Form
    {
        //Creates FrmWordle instance to refer to variables on that form
        private frmWordle FrmWordle = new frmWordle();
        private frmHelp FrmHelp = new frmHelp();
        private bool darkMode = true;
        private bool highContrastMode = false;
        //Accepts the instance of frmWordle assigned
        //to this form when it was instantiated

        public frmSettings(frmWordle frmWordleInstance)
        {
            //Constructs form
            InitializeComponent();
            //Makes the new instance of the wordle form equal
            //to the one already on screen, enabling us to actively edit
            //variables and invoke methods to instantly perform the
            //necessary visual augments
            FrmWordle = frmWordleInstance;
            if (FrmWordle.darkMode == true )
            {
                darkMode = true;
                chkDarkMode.Checked = true;
            }
            else 
            { 
                darkMode = false;
                chkDarkMode.Checked = false; 
            }
            if (FrmWordle.checkDictionary == true )
            {
                chkCheckDictionary.Checked = true;
            }
            else
            {
                chkCheckDictionary.Checked = false;
            }

        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {            
            if (chkDarkMode.Checked == true)
            {
                btnClose.BackgroundImage = Resources.imgCrossIconLight;

                FrmWordle.baseColour = Colours.darkBaseColour;
                FrmWordle.alternateColour = Colours.darkAlternateColour;
                FrmWordle.tertiaryColour = Colours.darkTertiaryColour;
                if (highContrastMode == false)
                {
                    FrmWordle.correctColour = Colours.darkCorrectColour;
                    FrmWordle.partialColour = Colours.darkPartialColour;
                }
                FrmWordle.textColour = Colours.darkTextColour;
                FrmWordle.darkMode = true;
                
            }
            else
            {
                btnClose.BackgroundImage = Resources.imgCrossIconDark;

                FrmWordle.baseColour = Colours.lightBaseColour;
                FrmWordle.alternateColour = Colours.lightAlternateColour;
                FrmWordle.tertiaryColour = Colours.lightTertiaryColour;
                if (highContrastMode == false)
                {
                    FrmWordle.correctColour = Colours.lightCorrectColour;
                    FrmWordle.partialColour = Colours.lightPartialColour;
                }
                FrmWordle.textColour = Colours.lightTextColour;
                FrmWordle.darkMode = false;
            }
            this.BackColor = FrmWordle.baseColour;
            btnClose.ForeColor = FrmWordle.baseColour;

            chkDarkMode.ForeColor = FrmWordle.textColour;
            chkCheckDictionary.ForeColor = FrmWordle.textColour;
            chkHighContrast.ForeColor = FrmWordle.textColour;
            lblGraphicsTitle.ForeColor = FrmWordle.textColour;
            lblChkDictWarning.ForeColor = FrmWordle.textColour;
            lblSupport.ForeColor = FrmWordle.textColour;


        }

        private void chkHighContrast_CheckedChanged(object sender, EventArgs e)
        {
            FrmWordle.correctColour = Colours.highContrastCorrectColour;
            FrmWordle.partialColour = Colours.highContrastPartialColour;
            if (chkHighContrast.Checked == true)
            {
                highContrastMode = true;
                FrmWordle.highContrast = true;
            }
            else
            {
                highContrastMode = false;
                FrmWordle.highContrast = false;
            }
        }

        private void chkCheckDictionary_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckDictionary.Checked == true)
            {
                FrmWordle.checkDictionary = true;
            }
            else
            {
                FrmWordle.checkDictionary = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            
            string mailto = "mailto:george.allman@education.nsw.gov.au";
            Process.Start(new ProcessStartInfo(mailto) { UseShellExecute = true });
            
        }
    }
}
