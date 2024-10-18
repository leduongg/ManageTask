using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoListProject.Models;

namespace ToDoListProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int currentPage = 1;
        static int itemsPerPage = 3;
        private int totalItems;
        private int totalPage;
        private DateTime dateTime = DateTime.Now;

        
        public MainWindow()
        {
            InitializeComponent();
            LoadDataToDo(1);
            //LoadDataDone(1);
            //LoadDataOverdue(1);
            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ToDoAndStatuses todo = (ToDoAndStatuses)lst_Todo.SelectedItem;
            if (todo == null) { return; }
            txt_Id_detail.Text = todo.ToDo.Id.ToString();
            txt_Name_detail.Text = todo.ToDo.Name;
            txt_Description_detail.Text = todo.ToDo.Description;
            date_Deadline_detail.SelectedDate = todo.ToDo.Deadline;
            cbo_Status_detail.ItemsSource = todo.AllStatus;
            cbo_Status_detail.SelectedItem = todo.SelectedStatus;
            cbo_Status_detail.DisplayMemberPath = "Name";
            tab_MainTab.SelectedIndex = 1;
        }

        private void LoadDataToDo(int currentPage)
        {
            using( var context = new ToDoListProjectContext())
            {
                //Create new list
                List<ToDoAndStatuses> lstItem = new List<ToDoAndStatuses>();
                List<ToDo> listToDo = new List<ToDo>();
                List<Status> listStatus = new List<Status>();
                
                //Get Data from database
                listStatus = context.Statuses.ToList();
                listToDo = context.ToDos.Where(t => t.StatusId != 1&&t.Deadline>dateTime).OrderBy(todo => todo.Deadline).ToList();

                //Create list of Item to bind in listView
               foreach(ToDo todo in listToDo)
                { 
                    lstItem.Add(new ToDoAndStatuses(todo, listStatus, todo.Status));
                }

                totalItems = lstItem.Count;
                totalPage = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                int startItem = (currentPage - 1) * itemsPerPage;

                //Paging
                List<PageNumber> PageNumbers = new List<PageNumber>();
                for (int i = 1; i <= totalPage; i++)
                {
                    PageNumbers.Add(new PageNumber(i));
                }
                ctrl_paging.ItemsSource = PageNumbers;

                
                lst_Todo.ItemsSource = lstItem.Skip(startItem).Take(itemsPerPage);
                
                
            }
        }

        private void LoadDataDone(int currentPage)
        {
            using (var context = new ToDoListProjectContext())
            {
                //Create new list
                List<ToDoAndStatuses> lstItem = new List<ToDoAndStatuses>();
                List<ToDo> listToDo = new List<ToDo>();
                List<Status> listStatus = new List<Status>();

                //Get Data from database
                listToDo = context.ToDos.Where(t => t.StatusId == 1 && t.Deadline > dateTime).OrderBy(todo => todo.Deadline).ToList();

                //Create list of Item to bind in listView
                foreach (ToDo todo in listToDo)
                {
                    lstItem.Add(new ToDoAndStatuses(todo, listStatus, todo.Status));
                }

                totalItems = lstItem.Count;
                totalPage = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                int startItem = (currentPage - 1) * itemsPerPage;

                //Paging
                List<PageNumber> PageNumbers = new List<PageNumber>();
                for (int i = 1; i <= totalPage; i++)
                {
                    PageNumbers.Add(new PageNumber(i));
                }
                ctrl_paging1.ItemsSource = PageNumbers;



                lst_Done.ItemsSource = lstItem.Skip(startItem).Take(itemsPerPage);
            }
        }
        private void LoadDataOverdue(int currentPage)
        {
            using (var context = new ToDoListProjectContext())
            {
                //Create new list
                List<ToDoAndStatuses> lstItem = new List<ToDoAndStatuses>();
                List<ToDo> listToDo = new List<ToDo>();
                List<Status> listStatus = new List<Status>();

                //Get Data from database
                listToDo = context.ToDos.Where(t =>t.Deadline <= dateTime).OrderByDescending(todo => todo.Deadline).ToList();

                //Create list of Item to bind in listView
                foreach (ToDo todo in listToDo)
                {
                    lstItem.Add(new ToDoAndStatuses(todo, listStatus, todo.Status));
                }

                totalItems = lstItem.Count;
                totalPage = (int)Math.Ceiling((double)totalItems / itemsPerPage);
                int startItem = (currentPage - 1) * itemsPerPage;
                //Paging
                List<PageNumber> PageNumbers = new List<PageNumber>();
                for (int i = 1; i <= totalPage; i++)
                {
                    PageNumbers.Add(new PageNumber(i));
                }
                ctrl_paging2.ItemsSource = PageNumbers;


                lst_overdue.ItemsSource = lstItem.Skip(startItem).Take(itemsPerPage);
            }
        }

        private void GoToPrevious()
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadDataToDo(currentPage);
                LoadDataDone(currentPage);
                LoadDataOverdue(currentPage);
            }
        }
        private void GoToNext()
        {
            if (currentPage < totalPage)
            {
                currentPage++;
                LoadDataToDo(currentPage);
                LoadDataDone(currentPage);
                LoadDataOverdue(currentPage);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GoToNext();
        }

        private void btn_previous_Click(object sender, RoutedEventArgs e)
        {
            GoToPrevious();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox combobox)
            {
                using (var context = new ToDoListProjectContext())
                {
                    try
                    {
                        ToDoAndStatuses tdStt = combobox.DataContext as ToDoAndStatuses;
                        lst_Todo.SelectedItem = tdStt;
                        if (tdStt != null)
                        {
                            tdStt.ToDo.Status = (Status)combobox.SelectedItem;
                            context.ToDos.Update(tdStt.ToDo);
                            context.SaveChanges();
                            LoadDataToDo(1);
                            LoadDataDone(1);
                            LoadDataOverdue(1);

                        }
                        tab_MainTab.SelectedIndex = 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is ToDoAndStatuses tdStt)
            {
                using (var context = new ToDoListProjectContext())
                {
                    try
                    {
                        tdStt.ToDo.Status = context.Statuses.Where(s => s.StatusId == 1).FirstOrDefault();
                        context.ToDos.Update(tdStt.ToDo);
                        context.SaveChanges();
                        LoadDataToDo(1);
                        LoadDataDone(1);
                        LoadDataOverdue(1);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                PageNumber pageNumber = button.DataContext as PageNumber;
                LoadDataToDo(pageNumber.pageNumber);
            }
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ToDoListProjectContext())
            {
                string Name = txt_Name.Text.Trim();
                string Description = txt_Description.Text;
                DateTime? Deadline = date_Deadline.SelectedDate;

                if (Name.IsNullOrEmpty())
                {
                    MessageBox.Show("Name cant be empty!");
                    return;
                }
                if (Description.IsNullOrEmpty())
                {
                    MessageBox.Show("Description cant be empty!");
                    return;
                }
                if (Deadline.HasValue)
                {
                    ToDo todo = new ToDo( Name, 2, Description, (DateTime)Deadline);
                    context.ToDos.Add(todo);
                    context.SaveChanges();
                    MessageBox.Show("Success!");
                    LoadDataToDo(1);
                    LoadDataDone(1);
                    LoadDataOverdue(1);
                }
                
            }
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new ToDoListProjectContext())
            {
                if (txt_Id_detail.Text.IsNullOrEmpty()) return;
                int id = int.Parse(txt_Id_detail.Text);
                string Name = txt_Name_detail.Text.Trim();
                string Description = txt_Description_detail.Text;
                DateTime? Deadline = date_Deadline_detail.SelectedDate;
                Status status = (Status)cbo_Status_detail.SelectedItem;

                if (Name.IsNullOrEmpty())
                {
                    MessageBox.Show("Name cant be empty!");
                    return;
                }
                if (Description.IsNullOrEmpty())
                {
                    MessageBox.Show("Description cant be empty!");
                    return;
                }
                if (Deadline.HasValue)
                {
                    ToDo todo;
                    todo = context.ToDos.FirstOrDefault(todo => todo.Id == id);
                    if (todo == null) return;
                    ToDo newTodo = new ToDo(id,Name, status.StatusId, Description, (DateTime)Deadline);
                    context.Entry(todo).CurrentValues.SetValues(newTodo);
                    context.SaveChanges();
                    MessageBox.Show("Success!");
                    LoadDataToDo(1);
                    LoadDataDone(1);
                    LoadDataOverdue(1);
                }

            }
        }

        private void btn_Export_Click(object sender, RoutedEventArgs e)
        {
            

            using(var context = new ToDoListProjectContext())
            {
                List<ToDo> listToDo = context.ToDos.ToList();
                string jsonContent;
                jsonContent = JsonSerializer.Serialize(listToDo,new JsonSerializerOptions { WriteIndented=true});
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "JSON Files (*.json)|.json";
                dialog.FileName = "ToDoList";
                if(dialog.ShowDialog() == true)
                {
                    string path = dialog.FileName;
                    txt_Jsonpath.Text = path;
                    File.WriteAllText(path, jsonContent);
                }
            }

            
            
        }

        private void btn_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "(*.json)|*.json";
            dialog.ShowDialog();
            String path = dialog.FileName;
            txt_Jsonpath.Text = path;
            if (path.IsNullOrEmpty()) return;
            List<ToDo> listToDo = new List<ToDo>();

            string jsonContent;
            jsonContent = File.ReadAllText(path);
            try
            {
                listToDo = JsonSerializer.Deserialize<List<ToDo>>(jsonContent);
                using(var context = new ToDoListProjectContext())
                {
                    foreach (ToDo t in listToDo)
                    {
                        ToDo todo = new ToDo(t.Name,t.StatusId,t.Description,t.Deadline);
                        context.ToDos.Add(todo);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btn_ReOpen_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                using (var context = new ToDoListProjectContext())
                {
                    try
                    {
                        ToDoAndStatuses tdStt = button.DataContext as ToDoAndStatuses;
                        lst_Todo.SelectedItem = tdStt;
                        if (tdStt != null)
                        {
                            tdStt.ToDo.Status = context.Statuses.Where(s => s.StatusId == 2).FirstOrDefault();
                            context.ToDos.Update(tdStt.ToDo);
                            context.SaveChanges();
                            LoadDataToDo(1);
                            LoadDataDone(1);
                            LoadDataOverdue(1);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void tab_MainTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (tab_MainTab.SelectedIndex)
            {
                case 2:
                    LoadDataDone(1);
                    break;
                case 4:
                    LoadDataOverdue(1);
                    break;
                default:
                    break;
            }
        }

        public void SetUserRole(int role)
        {
            if (role == 1)
            {
                it_Add.Visibility = Visibility.Collapsed;
                txt_Name_detail.IsReadOnly= true;
                txt_Description_detail.IsReadOnly = true;
                date_Deadline_detail.IsEnabled = false;
                cbo_Status_detail.IsEnabled = false;
                btn_Save.Visibility= Visibility.Collapsed;
                //row_reOpen.Visibility = Visibility.Collapsed;
            }
            else if (role == 0)
            {
                
            }
            else
            {
                MessageBox.Show("Wrong");
            }
        }
    }
}
