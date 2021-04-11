using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;

namespace WebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AtualizarTabela();
        }

        protected void ExcluirCliente_Click(object sender, EventArgs e)
        {
            var IdCliente = Convert.ToInt32((sender as LinkButton).Attributes["id_cliente"]);
            ClienteDAO.Excluir(IdCliente);
            Response.Redirect(Request.RawUrl);
        }

        protected void EditarCliente_Click(object sender, EventArgs e)
        {
            var IdCliente = Convert.ToInt32((sender as LinkButton).Attributes["id_cliente"]);
            var Cliente = ClienteDAO.BuscarClientePorId(IdCliente);

            PreencherModal(Cliente);
        }

        protected void btnSalvarCliente_Click(object sender, EventArgs e)
        {
            var Endereco = new Endereco
            {
                Rua = CampoRua.Value,
                Bairro = CampoBairro.Value,
                Numero = CampoNumero.Value,
                Cidade = CampoCidade.Value,
                Estado = CampoEstado.Value,
                CEP = CampoCEP.Value,
                Complemento = CampoComplemento.Value
            };

            var Telefone = new Telefone { Numero = CampoTelefone.Value };

            var Cliente = new Cliente
            {
                Id = !CampoId.Value.Equals("") ? Convert.ToInt32(CampoId.Value) : 0,
                Nome = CampoNome.Value,
                Email = CampoEmail.Value,
                Telefone = Telefone,
                RG = CampoRG.Value,
                CPF = CampoCPF.Value,
                Endereco = Endereco
            };

            ClienteDAO.Salvar(Cliente);

            Response.Redirect(Request.RawUrl);
        }


        private void PreencherModal(Cliente Cliente)
        {
            CampoId.Value = Cliente.Id.ToString();
            CampoNome.Value = Cliente.Nome;
            CampoEmail.Value = Cliente.Email;
            CampoRG.Value = Cliente.RG;
            CampoCPF.Value = Cliente.CPF;

            CampoTelefone.Value = Cliente.Telefone.Numero;

            CampoRua.Value = Cliente.Endereco.Rua;
            CampoBairro.Value = Cliente.Endereco.Bairro;
            CampoNumero.Value = Cliente.Endereco.Numero;
            CampoCidade.Value = Cliente.Endereco.Cidade;
            CampoEstado.Value = Cliente.Endereco.Estado;
            CampoCEP.Value = Cliente.Endereco.CEP;
            CampoComplemento.Value = Cliente.Endereco.Complemento;
        }

        private void AtualizarTabela()
        {
            var Clientes = ClienteDAO.BuscarClientes();

            Clientes.ForEach(x =>
            {
                var tableRow = new TableRow();
                tableRow.Cells.Add(new TableCell { Text = x.Nome });
                tableRow.Cells.Add(new TableCell { Text = x.Telefone.Numero });
                tableRow.Cells.Add(new TableCell { Text = x.Email });
                tableRow.Cells.Add(new TableCell { Text = x.CPF });

                var LinkEditar = new LinkButton();
                LinkEditar.Text = "<i class='fas fa-edit'></i>";
                LinkEditar.Click += new EventHandler(EditarCliente_Click);
                LinkEditar.Attributes.Add("id_cliente", x.Id.ToString());
                LinkEditar.Attributes.Add("class", "editar_cliente");

                var LinkExcluir = new LinkButton();
                LinkExcluir.Text = "<i class='fas fa-trash'></i>";
                LinkExcluir.Click += new EventHandler(ExcluirCliente_Click);
                LinkExcluir.Attributes.Add("id_cliente", x.Id.ToString());

                var CellEditar = new TableCell();
                CellEditar.Controls.Add(LinkEditar);

                var CellExcluir = new TableCell();
                CellExcluir.Controls.Add(LinkExcluir);

                tableRow.Cells.Add(CellEditar);
                tableRow.Cells.Add(CellExcluir);


                TabelaClientes.Rows.Add(tableRow);
            });
        }

    }
}