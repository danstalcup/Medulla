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
        private BattleEngine battleEngine;
        public Form1(BattleEngine battleEngine)
        {
            this.battleEngine = battleEngine;
            battleEngine.StartBattle();
            InitializeComponent();            
            ResetMenus();
        }

        private void UpdateBrowserDisplay()
        {
            webBrowser1.DocumentText = battleEngine.GetBattleRenderHtml();
            var playerTurn = battleEngine.IsPlayerTurn;
            listBox1.Visible = playerTurn;
            listBox2.Visible = playerTurn;
            listBox3.Visible = playerTurn;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            battleEngine.SetSelectedBattleActionType(listBox1.Text);
            listBox2.DataSource = battleEngine.GetBattleActions();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            battleEngine.SetSelectedBattleAction(listBox2.Text);
            listBox3.DataSource = battleEngine.GetBattleTargets();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            battleEngine.SetSelectedBattleActionTarget(listBox3.Text);
            UpdateBrowserDisplay();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            battleEngine.ProcessBattleAction();
            UpdateBrowserDisplay();
            ResetMenus();
        }

        private void ResetMenus()
        {
            listBox1.DataSource = battleEngine.GetBattleActionTypes();
        }
    }
}
