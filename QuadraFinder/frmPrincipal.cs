﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuadraFinder
{
    public partial class Principal: Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void quadraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarQuadra formulario = new frmCadastrarQuadra();
            formulario.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarUser formulario = new frmCadastrarUser();
            formulario.ShowDialog();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBuscarUser formulario = new frmBuscarUser();
            formulario.ShowDialog();
        }

        private void quadraToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBuscarQuadra formulario = new frmBuscarQuadra();
            formulario.ShowDialog();
        }
    }
}
