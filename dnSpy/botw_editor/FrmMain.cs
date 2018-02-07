using System;
using System.ComponentModel;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace botw_editor
{
	// Token: 0x02000009 RID: 9
	public partial class FrmMain : Form
	{
		// Token: 0x06000099 RID: 153 RVA: 0x0000DDFC File Offset: 0x0000BFFC
		public FrmMain()
		{
			this.InitializeComponent();
			Application.CurrentCulture = CultureInfo.InvariantCulture;
			this.lblVersion.Text = "Version " + this.CurrentVersion + this.revision;
			this.lblLockHealthInfo.Text = "";
			this.lblLockStaminaInfo.Text = "";
			this.lblPowersDarukInfo.Text = "";
			this.lblPowersMiphaInfo.Text = "";
			this.lblPowersRevaliInfo.Text = "";
			this.lblPowersUrbosaInfo.Text = "";
			this.lblUnbreakableBowsInfo.Text = "";
			this.lblUnbreakableShieldsInfo.Text = "";
			this.lblUnbreakableWeaponsInfo.Text = "";
			this.lblUnlimitAmiiboInfo.Text = "";
			this.myApp = new App(this);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600009A RID: 154 RVA: 0x0000DEF7 File Offset: 0x0000C0F7
		public string CurrentVersion
		{
			get
			{
				if (!ApplicationDeployment.IsNetworkDeployed)
				{
					return Assembly.GetExecutingAssembly().GetName().Version.ToString();
				}
				return ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}
		}

		// Token: 0x0600009B RID: 155 RVA: 0x0000DF24 File Offset: 0x0000C124
		public void SetLblScan(string text)
		{
			this.lblScan.Text = text;
			Application.DoEvents();
		}

		// Token: 0x0600009C RID: 156 RVA: 0x0000DF38 File Offset: 0x0000C138
		public void Putlog(string text)
		{
			string text2 = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
			this.txtLog.AppendText(string.Concat(new string[]
			{
				"[",
				text2,
				"] ",
				text,
				Environment.NewLine
			}));
		}

		// Token: 0x0600009D RID: 157 RVA: 0x0000DF93 File Offset: 0x0000C193
		private void btnScan_Click(object sender, EventArgs e)
		{
			this.myApp.requestMemoryScan();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000DFA0 File Offset: 0x0000C1A0
		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.myApp.worker.CancelAsync();
			Thread.Sleep(10);
		}

		// Token: 0x0600009F RID: 159 RVA: 0x0000DFB9 File Offset: 0x0000C1B9
		private void btnGameProcessPause_Click(object sender, EventArgs e)
		{
			this.myApp.suspendGame();
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x0000DFC6 File Offset: 0x0000C1C6
		private void btnGameProcessResume_Click(object sender, EventArgs e)
		{
			this.myApp.resumeGame();
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000DFD4 File Offset: 0x0000C1D4
		private void btnSettingsSave_Click(object sender, EventArgs e)
		{
			if (this.myApp.writeSettings(this.myApp.getCurrentSettings(), Settings.getConfigFilePath()))
			{
				MessageBox.Show("Settings saved.");
				this.Putlog("Settings saved.");
				return;
			}
			MessageBox.Show("An error occured.");
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000E020 File Offset: 0x0000C220
		private void btnSettingsClear_Click(object sender, EventArgs e)
		{
			this.myApp.resetSettings();
			Settings currentSettings = this.myApp.getCurrentSettings();
			currentSettings.auto_update = false;
			currentSettings.auto_update_timer = 15;
			for (int i = 0; i < currentSettings.action_datas.Count; i++)
			{
				actiondata actiondata = new actiondata();
				actiondata.section = currentSettings.action_datas[i].section;
				currentSettings.action_datas[i] = actiondata;
			}
			currentSettings.custom_actions.Clear();
			this.myApp.applySettings(currentSettings);
			this.Putlog("Settings cleared.");
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x0000E0B8 File Offset: 0x0000C2B8
		private void btnSettingsExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.AddExtension = true;
			saveFileDialog.DefaultExt = "xml";
			saveFileDialog.FileName = "config.xml";
			saveFileDialog.Filter = "XML files (*.xml)|*.xml";
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				if (saveFileDialog.FileName.Length > 0 && this.myApp.writeSettings(this.myApp.getCurrentSettings(), saveFileDialog.FileName))
				{
					MessageBox.Show("Settings exported.");
					return;
				}
				MessageBox.Show("Error exporting settings.");
			}
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000E140 File Offset: 0x0000C340
		private void btnSettingsImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.AddExtension = true;
			openFileDialog.DefaultExt = "xml";
			openFileDialog.Filter = "XML files (*.xml)|*.xml";
			openFileDialog.FileName = "";
			if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileName != "" && File.Exists(openFileDialog.FileName))
			{
				Settings s = this.myApp.readSettings(openFileDialog.FileName);
				this.myApp.applySettings(s);
				this.Putlog("Settings imported from " + openFileDialog.FileName);
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000E1D8 File Offset: 0x0000C3D8
		private void btnRunSpeedUpdate_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed());
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000E1F0 File Offset: 0x0000C3F0
		private void btnRunSpeedDefault_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(1.0);
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000E206 File Offset: 0x0000C406
		private void btnRunSpeedUp_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed() + 0.25);
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x0000E228 File Offset: 0x0000C428
		private void btnRunSpeedDown_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateRunSpeedMultiplier(this.myApp.GetTxtRunSpeed() - 0.25);
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x0000E24A File Offset: 0x0000C44A
		private void btnPositionSave_Click(object sender, EventArgs e)
		{
			this.myApp.SavePosition();
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000E257 File Offset: 0x0000C457
		private void btnPositionRestore_Click(object sender, EventArgs e)
		{
			this.myApp.RestorePosition();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x0000E264 File Offset: 0x0000C464
		private void btnPositionJump_Click(object sender, EventArgs e)
		{
			this.myApp.JumpPosition();
		}

		// Token: 0x060000AC RID: 172 RVA: 0x0000E271 File Offset: 0x0000C471
		private void btnPositionEdit_Click(object sender, EventArgs e)
		{
			this.myApp.SwitchEditPosition();
		}

		// Token: 0x060000AD RID: 173 RVA: 0x0000E27E File Offset: 0x0000C47E
		private void btnCapturedPositionNew_Click(object sender, EventArgs e)
		{
			this.myApp.AddCapturedPosition();
		}

		// Token: 0x060000AE RID: 174 RVA: 0x0000E28B File Offset: 0x0000C48B
		private void btnCapturedPositionSave_Click(object sender, EventArgs e)
		{
			this.myApp.SaveCapturedPosition();
		}

		// Token: 0x060000AF RID: 175 RVA: 0x0000E298 File Offset: 0x0000C498
		private void btnCapturedPositionRemove_Click(object sender, EventArgs e)
		{
			this.myApp.RemoveCapturedPosition();
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000E2A5 File Offset: 0x0000C4A5
		private void btnCapturedPositionTP_Click(object sender, EventArgs e)
		{
			this.myApp.TPCapturedPosition();
		}

		// Token: 0x060000B1 RID: 177 RVA: 0x0000E2B2 File Offset: 0x0000C4B2
		private void btnRefreshWeaponsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Weapons");
		}

		// Token: 0x060000B2 RID: 178 RVA: 0x0000E2C4 File Offset: 0x0000C4C4
		private void btnRefreshBowsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Bows");
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000E2D6 File Offset: 0x0000C4D6
		private void btnRefreshShieldsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.RefreshTxtSlot("Shields");
		}

		// Token: 0x060000B4 RID: 180 RVA: 0x0000E2E8 File Offset: 0x0000C4E8
		private void btnUpdateWeaponsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Weapons", this.myApp.GetTxtSlot("Weapons"));
		}

		// Token: 0x060000B5 RID: 181 RVA: 0x0000E30A File Offset: 0x0000C50A
		private void btnUpdateBowsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Bows", this.myApp.GetTxtSlot("Bows"));
		}

		// Token: 0x060000B6 RID: 182 RVA: 0x0000E32C File Offset: 0x0000C52C
		private void btnUpdateShieldsSlots_Click(object sender, EventArgs e)
		{
			this.myApp.UpdateSlot("Shields", this.myApp.GetTxtSlot("Shields"));
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000E350 File Offset: 0x0000C550
		private void numInternalLoopMs_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.nbInternalLoopMs = this.myApp.getInternalLoopMsValue();
			this.Putlog("Internal Loop timings set to : " + this.myApp.nbInternalLoopMs + " ms");
		}

		// Token: 0x060000B8 RID: 184 RVA: 0x0000E3A4 File Offset: 0x0000C5A4
		private void numSpacingMs_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.nbSpacingMs = this.myApp.getSpacingMsValue();
			this.Putlog("Spacing timings set to : " + this.myApp.nbSpacingMs + " ms");
		}

		// Token: 0x060000B9 RID: 185 RVA: 0x0000E3F5 File Offset: 0x0000C5F5
		private void button1_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.dumpMemoryToFile("dump.dmp");
		}

		// Token: 0x060000BA RID: 186 RVA: 0x0000E410 File Offset: 0x0000C610
		private void button2_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.compareMemory("dump.dmp");
		}

		// Token: 0x060000BB RID: 187 RVA: 0x0000E42C File Offset: 0x0000C62C
		private void button3_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			string str = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss", CultureInfo.InvariantCulture);
			this.myApp.generateCompareReport("memory_changes_" + str + ".txt");
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000E478 File Offset: 0x0000C678
		private void btnFindMemoryRegionByAddress_Click(object sender, EventArgs e)
		{
			long addr = MemAPI.HexStringToInt64(this.txtFindMemoryRegionByAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.searchMemoryRegionForAddress(addr);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000E4AC File Offset: 0x0000C6AC
		private void btntxtFindMemoryRegionBySize_Click(object sender, EventArgs e)
		{
			long size = MemAPI.HexStringToInt64(this.txtFindMemoryRegionBySize.Text);
			long startAddress = MemAPI.HexStringToInt64(this.txtFindMemoryRegionByAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.searchMemoryRegionForSize(size, startAddress);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000E4F1 File Offset: 0x0000C6F1
		private void btnMemoryRegions_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.listMemoryRegions();
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000E508 File Offset: 0x0000C708
		private void trackTime_ValueChanged(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			if (this.trackTime.Tag != null)
			{
				return;
			}
			int value = this.trackTime.Value;
			this.myApp.setTime(value);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000E544 File Offset: 0x0000C744
		private void btnCompareAddress_Click(object sender, EventArgs e)
		{
			long address = MemAPI.HexStringToInt64(this.txtCompareAddress.Text);
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.showCompareAddress(address);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0000E577 File Offset: 0x0000C777
		private void btnNoStaminaBar_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.enableStaminaBar(false);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x0000E58E File Offset: 0x0000C78E
		private void btnRestoreStaminaBar_Click(object sender, EventArgs e)
		{
			if (this.myApp == null)
			{
				return;
			}
			this.myApp.enableStaminaBar(true);
		}

		// Token: 0x0400005C RID: 92
		private App myApp;

		// Token: 0x0400005D RID: 93
		public string revision = "d";
	}
}
