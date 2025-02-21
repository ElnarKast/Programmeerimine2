using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();
        private const string ApiBaseUrl = "http://localhost:5000/api/objects"; // Замените на URL вашего API

        public MainWindow()
        {
            InitializeComponent();
        }

        // Загрузка списка объектов
        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var objects = await GetObjectsAsync();
                ObjectListBox.ItemsSource = objects;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }

        // Добавление нового объекта
        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var newObject = new MyObject { Name = ObjectNameTextBox.Text };
            try
            {
                if (string.IsNullOrWhiteSpace(newObject.Name))
                {
                    MessageBox.Show("Введите имя объекта.");
                    return;
                }

                await AddObjectAsync(newObject);
                LoadButton_Click(null, null); // Перезагрузить список после добавления
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении объекта: {ex.Message}");
            }
        }

        // Удаление выбранного объекта
        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ObjectListBox.SelectedItem is MyObject selectedObject)
            {
                try
                {
                    if (selectedObject?.Id == 0)
                    {
                        MessageBox.Show("Невозможно удалить объект с неустановленным Id.");
                        return;
                    }

                    await DeleteObjectAsync(selectedObject.Id);
                    LoadButton_Click(null, null); // Перезагрузить список после удаления
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении объекта: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите объект для удаления.");
            }
        }

        // Сохранение измененного объекта
        private async void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ObjectListBox.SelectedItem is MyObject selectedObject)
            {
                selectedObject.Name = ObjectNameTextBox.Text; // Новый имя

                try
                {
                    if (string.IsNullOrWhiteSpace(selectedObject.Name))
                    {
                        MessageBox.Show("Имя объекта не может быть пустым.");
                        return;
                    }

                    await SaveObjectAsync(selectedObject);
                    LoadButton_Click(null, null); // Перезагрузить список после сохранения
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении объекта: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите объект для сохранения.");
            }
        }

        // Получение списка объектов через API
        private async Task<List<MyObject>> GetObjectsAsync()
        {
            try
            {
                var response = await client.GetStringAsync(ApiBaseUrl);
                return JsonConvert.DeserializeObject<List<MyObject>>(response);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при получении данных: {ex.Message}");
                return new List<MyObject>(); // Возвращаем пустой список в случае ошибки
            }
        }

        // Добавление нового объекта через API
        private async Task AddObjectAsync(MyObject newObject)
        {
            var json = JsonConvert.SerializeObject(newObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(ApiBaseUrl, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка при добавлении объекта: {response.ReasonPhrase}");
            }
        }

        // Обновление объекта через API
        private async Task SaveObjectAsync(MyObject updatedObject)
        {
            var json = JsonConvert.SerializeObject(updatedObject);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"{ApiBaseUrl}/{updatedObject.Id}", content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка при обновлении объекта: {response.ReasonPhrase}");
            }
        }

        // Удаление объекта через API
        private async Task DeleteObjectAsync(int id)
        {
            var response = await client.DeleteAsync($"{ApiBaseUrl}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Ошибка при удалении объекта: {response.ReasonPhrase}");
            }
        }
    }

    // Класс для представления объекта
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
