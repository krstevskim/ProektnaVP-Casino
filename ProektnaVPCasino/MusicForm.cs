﻿using System.Windows.Forms;
namespace ProektnaVPCasino
{
    public partial class MusicForm : Form
    {
        WMPLib.IWMPControls3 controls;
        public MusicForm()
        {
            InitializeComponent();
            WMPLib.IWMPPlaylist playlist = axWindowsMediaPlayer1.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            media = axWindowsMediaPlayer1.newMedia(@"https://vpprojectcasino.000webhostapp.com/music/pokerMusic.mp3");
            playlist.appendItem(media);
            axWindowsMediaPlayer1.currentPlaylist = playlist;
            controls = (WMPLib.IWMPControls3)axWindowsMediaPlayer1.Ctlcontrols;
        }
        
        private void MusicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }
    }
}
