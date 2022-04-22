using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.ViewModels;


namespace AbstractBarView
{
    public partial class FormWarehouse : Form
    {
        public int Id { set { id = value; } }

        private readonly IWarehouseLogic logic;

        private int? id;

        private Dictionary<int, (string, int)> warehouseComponents;

        public FormWarehouse(IWarehouseLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    WarehouseViewModel view = logic.Read(new WarehouseBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.WarehouseName;
                        textBoxFIO.Text = view.ResponsiblePerson;
                        warehouseComponents = view.WarehouseComponents;
                        if (warehouseComponents != null)
                        {
                            dataGridView.Rows.Clear();
                            foreach (var wt in warehouseComponents)
                            {
                                dataGridView.Rows.Add(new object[] { wt.Key, wt.Value.Item1, wt.Value.Item2 });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                warehouseComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new WarehouseBindingModel
                {
                    Id = id,
                    WarehouseName = textBoxName.Text,
                    ResponsiblePerson = textBoxFIO.Text,
                    WarehouseComponents = warehouseComponents,
                    DateCreate = DateTime.Now
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
