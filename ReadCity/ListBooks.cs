using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;

namespace ReadCity
{
    public partial class ListBooks : Form
    {
        private string _fullName;
        private FlowLayoutPanel flowPanel;
        private Image _bookPlaceholder;
        private List<Book> _allBooks;

        // Элементы фильтрации
        private Panel filterPanel;
        private TextBox searchTextBox;
        private ComboBox authorComboBox;
        private ComboBox genreComboBox;
        private ComboBox publisherComboBox;
        private ComboBox yearComboBox;
        private ComboBox sortComboBox;
        private Button resetFilterButton;

        public ListBooks(string fullName)
        {
            InitializeComponent();
            _fullName = fullName;
            labelFullName.Text = fullName;

            // Загружаем картинку из ресурсов
            _bookPlaceholder = Properties.Resources.book_placeholder;

            InitializeFilterPanel();
            LoadBooks();
        }

        private void InitializeFilterPanel()
        {
            // Создаем компактную панель фильтрации сверху
            filterPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 45,
                BackColor = Color.FromArgb(240, 240, 240),
                Padding = new Padding(5)
            };

            // Поиск по названию
            Label searchLabel = new Label
            {
                Text = "Поиск:",
                Location = new Point(5, 12),
                Size = new Size(40, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(searchLabel);

            searchTextBox = new TextBox
            {
                Location = new Point(45, 10),
                Size = new Size(150, 23),
                PlaceholderText = "Название книги..."
            };
            searchTextBox.TextChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(searchTextBox);

            // Фильтр по автору
            Label authorLabel = new Label
            {
                Text = "Автор:",
                Location = new Point(205, 12),
                Size = new Size(40, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(authorLabel);

            authorComboBox = new ComboBox
            {
                Location = new Point(245, 10),
                Size = new Size(120, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            authorComboBox.SelectedIndexChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(authorComboBox);

            // Фильтр по жанру
            Label genreLabel = new Label
            {
                Text = "Жанр:",
                Location = new Point(375, 12),
                Size = new Size(40, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(genreLabel);

            genreComboBox = new ComboBox
            {
                Location = new Point(415, 10),
                Size = new Size(120, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            genreComboBox.SelectedIndexChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(genreComboBox);

            // Фильтр по издательству
            Label publisherLabel = new Label
            {
                Text = "Изд-во:",
                Location = new Point(545, 12),
                Size = new Size(45, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(publisherLabel);

            publisherComboBox = new ComboBox
            {
                Location = new Point(590, 10),
                Size = new Size(110, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            publisherComboBox.SelectedIndexChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(publisherComboBox);

            // Фильтр по году издания
            Label yearLabel = new Label
            {
                Text = "Год:",
                Location = new Point(710, 12),
                Size = new Size(35, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(yearLabel);

            yearComboBox = new ComboBox
            {
                Location = new Point(745, 10),
                Size = new Size(80, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            yearComboBox.SelectedIndexChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(yearComboBox);

            // Сортировка
            Label sortLabel = new Label
            {
                Text = "Сортировка:",
                Location = new Point(835, 12),
                Size = new Size(65, 20),
                Font = new Font("Segoe UI", 9)
            };
            filterPanel.Controls.Add(sortLabel);

            sortComboBox = new ComboBox
            {
                Location = new Point(900, 10),
                Size = new Size(130, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            sortComboBox.Items.AddRange(new object[] { "По умолчанию", "Доступно (сначала много)", "Доступно (сначала мало)" });
            sortComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndexChanged += (s, e) => ApplyFilters();
            filterPanel.Controls.Add(sortComboBox);

            // Кнопка сброса
            resetFilterButton = new Button
            {
                Text = "Сбросить",
                Location = new Point(1040, 9),
                Size = new Size(70, 25),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            resetFilterButton.FlatAppearance.BorderSize = 0;
            resetFilterButton.Click += ResetFilterButton_Click;
            filterPanel.Controls.Add(resetFilterButton);

            panelBooks.Controls.Add(filterPanel);
        }

        private void LoadBooks()
        {
            using (LibraryReadCityContext db = new LibraryReadCityContext())
            {
                _allBooks = db.Books.ToList();

                // Заполняем комбобоксы уникальными значениями
                FillComboBoxes();

                // Отображаем книги
                ApplyFilters();
            }
        }

        private void FillComboBoxes()
        {
            // Добавляем пункт "Все" в начало
            var authors = _allBooks.Select(b => b.Author).Distinct().OrderBy(a => a).ToList();
            authors.Insert(0, "Все");
            authorComboBox.DataSource = authors.ToList();
            authorComboBox.SelectedIndex = 0;

            var genres = _allBooks.Select(b => b.Genre).Distinct().OrderBy(g => g).ToList();
            genres.Insert(0, "Все");
            genreComboBox.DataSource = genres.ToList();
            genreComboBox.SelectedIndex = 0;

            var publishers = _allBooks.Select(b => b.PublishingHouse).Distinct().OrderBy(p => p).ToList();
            publishers.Insert(0, "Все");
            publisherComboBox.DataSource = publishers.ToList();
            publisherComboBox.SelectedIndex = 0;

            var years = _allBooks.Select(b => b.YearOfPublication).Distinct().OrderBy(y => y).ToList();
            years.Insert(0, 0);
            yearComboBox.DataSource = years.ToList();
            yearComboBox.DisplayMember = "ToString";
            yearComboBox.SelectedIndex = 0;
        }

        private void ApplyFilters()
        {
            // Очищаем существующие карточки
            if (flowPanel != null)
            {
                flowPanel.Dispose();
            }

            // Создаем новую панель с прокруткой
            flowPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10, 10, 20, 10),
                BackColor = Color.White
            };
            panelBooks.Controls.Add(flowPanel);

            // Применяем фильтрацию
            var filteredBooks = ApplyFiltersToBooks();

            // Применяем сортировку
            filteredBooks = ApplySortingToBooks(filteredBooks);

            if (!filteredBooks.Any())
            {
                Label noBooksLabel = new Label
                {
                    Text = "Книги не найдены",
                    Font = new Font("Segoe UI", 16F),
                    ForeColor = Color.Gray,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Height = 100
                };
                flowPanel.Controls.Add(noBooksLabel);
                return;
            }

            foreach (var book in filteredBooks)
            {
                var card = CreateBookCard(book);
                flowPanel.Controls.Add(card);
            }
        }

        private List<Book> ApplyFiltersToBooks()
        {
            var filtered = _allBooks.AsQueryable();

            // Поиск по названию
            string searchText = searchTextBox.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                filtered = filtered.Where(b => b.Name.ToLower().Contains(searchText));
            }

            // Фильтр по автору
            if (authorComboBox.SelectedItem != null && authorComboBox.SelectedItem.ToString() != "Все")
            {
                string selectedAuthor = authorComboBox.SelectedItem.ToString();
                filtered = filtered.Where(b => b.Author == selectedAuthor);
            }

            // Фильтр по жанру
            if (genreComboBox.SelectedItem != null && genreComboBox.SelectedItem.ToString() != "Все")
            {
                string selectedGenre = genreComboBox.SelectedItem.ToString();
                filtered = filtered.Where(b => b.Genre == selectedGenre);
            }

            // Фильтр по издательству
            if (publisherComboBox.SelectedItem != null && publisherComboBox.SelectedItem.ToString() != "Все")
            {
                string selectedPublisher = publisherComboBox.SelectedItem.ToString();
                filtered = filtered.Where(b => b.PublishingHouse == selectedPublisher);
            }

            // Фильтр по году
            if (yearComboBox.SelectedItem != null && Convert.ToInt32(yearComboBox.SelectedItem) != 0)
            {
                short selectedYear = Convert.ToInt16(yearComboBox.SelectedItem);
                filtered = filtered.Where(b => b.YearOfPublication == selectedYear);
            }

            return filtered.ToList();
        }

        private List<Book> ApplySortingToBooks(List<Book> books)
        {
            if (sortComboBox.SelectedItem == null)
                return books;

            string sortOption = sortComboBox.SelectedItem.ToString();

            switch (sortOption)
            {
                case "Доступно (сначала много)":
                    return books.OrderByDescending(b => b.Available).ToList();
                case "Доступно (сначала мало)":
                    return books.OrderBy(b => b.Available).ToList();
                default:
                    return books;
            }
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            // Сбрасываем все фильтры
            searchTextBox.Text = "";
            authorComboBox.SelectedItem = "Все";
            genreComboBox.SelectedItem = "Все";
            publisherComboBox.SelectedItem = "Все";
            yearComboBox.SelectedItem = 0;
            sortComboBox.SelectedIndex = 0;
        }

        private Panel CreateBookCard(Book book)
        {
            // Основная карточка
            Panel card = new Panel
            {
                Width = flowPanel.Width - 35,
                Height = 260,
                Margin = new Padding(0, 0, 0, 10),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Картинка книги слева (растянута на всю высоту с отступами)
            PictureBox pictureBox = new PictureBox
            {
                Location = new Point(10, 10),
                Size = new Size(120, card.Height - 20),
                BackColor = Color.FromArgb(240, 240, 240),
                SizeMode = PictureBoxSizeMode.Zoom,
                Image = _bookPlaceholder
            };
            card.Controls.Add(pictureBox);

            // Название книги (сверху)
            Label titleLabel = new Label
            {
                Text = book.Name,
                Location = new Point(140, 10),
                Width = card.Width - 300,
                Height = 35,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            card.Controls.Add(titleLabel);

            // Доступное количество - справа от названия
            Label availableLabel = new Label
            {
                Text = $"Доступно: {book.Available}",
                Location = new Point(card.Width - 150, 10),
                Width = 140,
                Height = 35,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = book.Available > 0 ? Color.Green : Color.Red,
                TextAlign = ContentAlignment.MiddleRight
            };
            card.Controls.Add(availableLabel);

            // Вся остальная информация под названием (в две колонки)
            // Левая колонка
            Label authorLabel = new Label
            {
                Text = $"Автор: {book.Author}",
                Location = new Point(140, 55),
                Width = 250,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(authorLabel);

            Label genreLabel = new Label
            {
                Text = $"Жанр: {book.Genre}",
                Location = new Point(140, 85),
                Width = 250,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(genreLabel);

            Label publisherLabel = new Label
            {
                Text = $"Издательство: {book.PublishingHouse}",
                Location = new Point(140, 115),
                Width = 250,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(publisherLabel);

            // Правая колонка
            Label isbnLabel = new Label
            {
                Text = $"ISBN: {book.Isbn}",
                Location = new Point(420, 55),
                Width = 200,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(isbnLabel);

            Label yearLabel = new Label
            {
                Text = $"Год издания: {book.YearOfPublication}",
                Location = new Point(420, 85),
                Width = 200,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(yearLabel);

            Label pagesLabel = new Label
            {
                Text = $"Страниц: {book.Pages}",
                Location = new Point(420, 115),
                Width = 200,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(pagesLabel);

            Label totalLabel = new Label
            {
                Text = $"Всего экземпляров: {book.Total}",
                Location = new Point(420, 145),
                Width = 200,
                Height = 25,
                Font = new Font("Segoe UI", 10)
            };
            card.Controls.Add(totalLabel);

            // Заголовок "Аннотация:"
            Label annotationTitle = new Label
            {
                Text = "Аннотация:",
                Location = new Point(140, 155),
                Width = 100,
                Height = 20,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };
            card.Controls.Add(annotationTitle);

            // Панель с текстом аннотации
            Panel annotationPanel = new Panel
            {
                Location = new Point(140, 175),
                Width = card.Width - 150,
                Height = 75,
                BackColor = Color.FromArgb(248, 248, 248),
                BorderStyle = BorderStyle.FixedSingle
            };

            Label annotationText = new Label
            {
                Text = book.Annotation.Length > 200 ? book.Annotation.Substring(0, 200) + "..." : book.Annotation,
                Location = new Point(5, 5),
                Width = annotationPanel.Width - 10,
                Height = 65,
                Font = new Font("Segoe UI", 9),
                AutoEllipsis = true
            };
            annotationPanel.Controls.Add(annotationText);

            card.Controls.Add(annotationPanel);

            return card;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            new Authorization().Show();
            this.Close();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (flowPanel != null)
            {
                foreach (Panel card in flowPanel.Controls)
                {
                    // Обновляем ширину карточки
                    card.Width = flowPanel.Width - 35;

                    // Обновляем размер картинки (растягиваем по высоте)
                    PictureBox pictureBox = card.Controls.OfType<PictureBox>().FirstOrDefault();
                    if (pictureBox != null)
                    {
                        pictureBox.Size = new Size(120, card.Height - 20);
                    }

                    // Обновляем ширину названия
                    Label titleLabel = card.Controls.OfType<Label>().FirstOrDefault(l => l.Font.Bold && l.Font.Size == 14);
                    if (titleLabel != null)
                    {
                        titleLabel.Width = card.Width - 300;
                    }

                    // Обновляем позицию доступного количества
                    Label availableLabel = card.Controls.OfType<Label>().FirstOrDefault(l => l.Text.StartsWith("Доступно:"));
                    if (availableLabel != null)
                    {
                        availableLabel.Location = new Point(card.Width - 150, 10);
                    }

                    // Обновляем панель аннотации
                    Panel annotationPanel = card.Controls.OfType<Panel>().FirstOrDefault();
                    if (annotationPanel != null)
                    {
                        annotationPanel.Width = card.Width - 150;

                        Label annotationText = annotationPanel.Controls.OfType<Label>().FirstOrDefault();
                        if (annotationText != null)
                        {
                            annotationText.Width = annotationPanel.Width - 10;
                        }
                    }
                }
            }
        }
    }
}
