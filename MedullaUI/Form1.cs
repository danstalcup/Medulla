using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medulla.Core.Battles;
using Medulla.Engine;
using Medulla.Engine.Rendering;
using Medulla.Engine.TestBuilders;

namespace Medulla
{
    public partial class Form1 : Form
    {
        private GameEngine gameEngine;
        public Form1(GameEngine gameEngine)
        {
            this.gameEngine = gameEngine;
            gameEngine.StartBattle();
            InitializeComponent();            
            ResetMenus();
        }

        private void UpdateBrowserDisplay()
        {
            webBrowser1.DocumentText = gameEngine.GetBattleRenderHtml();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameEngine.SetSelectedBattleActionType(listBox1.Text);
            listBox2.DataSource = gameEngine.GetBattleActions();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameEngine.SetSelectedBattleAction(listBox2.Text);
            listBox3.DataSource = gameEngine.GetBattleTargets();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameEngine.SetSelectedBattleActionTarget(listBox3.Text);
            UpdateBrowserDisplay();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameEngine.ProcessBattleAction();
            UpdateBrowserDisplay();
            ResetMenus();
        }

        private void ResetMenus()
        {
            listBox1.DataSource = gameEngine.GetBattleActionTypes();
        }
    }
}
