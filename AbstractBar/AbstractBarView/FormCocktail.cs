using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbstractBarContracts.BindingModels;
using AbstractBarContracts.BusinessLogicsContracts;
using AbstractBarContracts.ViewModels;
using Unity;

namespace AbstractBarView
{
    public partial class FormCocktail : Form
    {
        public int Id { set { id = value; } }
        private readonly ICocktailLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> cocktailComponents;

        public FormCocktail(ICocktailLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormCocktail_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CocktailViewModel view = _logic.Read(new CocktailBindingModel{Id = id.Value})?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.CocktailName;
                        textBoxPrice.Text = view.Price.ToString();
                        cocktailComponents = view.CocktailComponents;
                        LoadData();
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
                cocktailComponents = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (cocktailComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in cocktailComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1,pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCocktailComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (cocktailComponents.ContainsKey(form.Id))
                {
                    cocktailComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    cocktailComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormCocktailComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = cocktailComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cocktailComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        cocktailComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                       MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (cocktailComponents == null || cocktailComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new CocktailBindingModel
                {
                    Id = id,
                    CocktailName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    CocktailComponents = cocktailComponents
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

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
