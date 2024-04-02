using DbContextLib;
using DbDataManager;
using Entities;
using Microsoft.EntityFrameworkCore;
using Model;

namespace API_Unit_Test;

public class DbManagerFormulaireTests
{
     private LibraryContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDbForFormulaireInMemory" + Guid.NewGuid()) // Unique name for each test execution
                .Options;
            var context = new LibraryContext(options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        }

        [Fact]
        public async Task GetAllForm_ReturnsForms_WithSpecifiedOrder()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                context.FormSet.AddRange(
                    new FormEntity { Theme = "C", DatePublication = "2021-01-01", Link = "http://c.com", UserEntityPseudo = "user1"  },
                    new FormEntity { Theme = "A", DatePublication = "2021-01-01", Link = "http://a.com", UserEntityPseudo = "user2" },
                    new FormEntity { Theme = "B", DatePublication = "2021-01-01", Link = "http://b.com", UserEntityPseudo = "user3"  }
                );
                context.SaveChanges();

                var service = new DbManagerFormulaire(context);

                // Act & Assert - Test ordering by theme
                var formsByTheme = await service.GetAllForm(0, 10, FormOrderCriteria.ByTheme);
                Assert.Equal("A", formsByTheme.First().Theme);

                // Test ordering by link
                var formsByLink = await service.GetAllForm(0, 10, FormOrderCriteria.ByLien);
                Assert.Equal("http://a.com", formsByLink.First().Lien);
            }
        }

        [Fact]
        public async Task GetById_ReturnsCorrectForm()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var expectedForm = new FormEntity { Id = 1, Theme = "Test Form", Link = "http://test.com", UserEntityPseudo = "user1"  };
                context.FormSet.Add(expectedForm);
                context.SaveChanges();

                var service = new DbManagerFormulaire(context);

                // Act
                var form = await service.GetById(1);

                // Assert
                Assert.NotNull(form);
                Assert.Equal("Test Form", form.Theme);
                Assert.Equal("http://test.com", form.Lien);
            }
        }

        [Fact]
        public async Task CreateForm_AddsNewFormSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var service = new DbManagerFormulaire(context);
                var newForm = new Formulaire { Theme = "New Form", Lien = "http://newform.com", UserPseudo = "user1", Date  = "2021-01-01"};

                // Act
                var createdForm = await service.CreateForm(newForm);

                // Assert
                Assert.NotNull(createdForm);
                Assert.Equal("New Form", createdForm.Theme);
                Assert.Equal("http://newform.com", createdForm.Lien);
                Assert.Single(context.FormSet);
            }
        }

        [Fact]
        public async Task UpdateForm_UpdatesExistingFormSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var originalForm = new FormEntity { Id = 2, Theme = "Original Theme", Link = "http://original.com",UserEntityPseudo = "user1",  DatePublication  = "2021-01-01"  };
                context.FormSet.Add(originalForm);
                context.SaveChanges();

                var service = new DbManagerFormulaire(context);
                var updatedForm = new Formulaire { Id = 2, Theme = "Updated Theme", Lien = "http://updated.com" };

                // Act
                var result = await service.UpdateForm(2, updatedForm);

                // Assert
                Assert.NotNull(result);
                Assert.Equal("Updated Theme", result.Theme);
                Assert.Equal("http://updated.com", result.Lien);
            }
        }

        [Fact]
        public async Task DeleteForm_RemovesFormSuccessfully()
        {
            using (var context = GetInMemoryDbContext())
            {
                // Arrange
                var formToDelete = new FormEntity { Id = 3, Theme = "Delete Me", Link = "http://delete.com", UserEntityPseudo = "user1"  };
                context.FormSet.Add(formToDelete);
                context.SaveChanges();

                var service = new DbManagerFormulaire(context);

                // Act
                var deletedForm = await service.DeleteForm(3);

                // Assert
                Assert.NotNull(deletedForm);
                Assert.DoesNotContain(context.FormSet, f => f.Id == 3);
            }
        }
        
    [Fact]
    public async Task GetById_NonExistentId_ReturnsNull()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var service = new DbManagerFormulaire(context);

            // Act
            var form = await service.GetById(999); // Assuming this ID doesn't exist

            // Assert
            Assert.Null(form);
        }
    }
    
    [Fact]
    public async Task UpdateForm_NonExistentForm_ReturnsNull()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var service = new DbManagerFormulaire(context);
            var nonExistentForm = new Formulaire { Id = 999, Theme = "Non-Existent Theme", UserPseudo = "user1"  };

            // Act
            var result = await service.UpdateForm(nonExistentForm.Id, nonExistentForm);

            // Assert
            Assert.Null(result);
        }
    }

    [Fact]
    public async Task DeleteForm_NonExistentId_ReturnsNull()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            var service = new DbManagerFormulaire(context);

            // Act
            var result = await service.DeleteForm(999); // Assuming this ID doesn't exist

            // Assert
            Assert.Null(result);
        }
    }

    [Fact]
    public async Task GetAllForm_InvalidCriteria_ReturnsAllWithoutOrder()
    {
        using (var context = GetInMemoryDbContext())
        {
            // Arrange
            context.FormSet.AddRange(
                new FormEntity { Theme = "C", DatePublication = "2021-01-01", Link = "http://c.com", UserEntityPseudo = "user1"},
                new FormEntity { Theme = "A", DatePublication = "2021-01-01", Link = "http://a.com", UserEntityPseudo = "user2"},
                new FormEntity { Theme = "B", DatePublication = "2021-01-01", Link = "http://b.com", UserEntityPseudo = "user3"}
            );
            context.SaveChanges();

            var service = new DbManagerFormulaire(context);

            // Act
            var forms = await service.GetAllForm(0, 10, (FormOrderCriteria)(-1));

            // Assert
            Assert.Equal(3, forms.Count());
        }
    }
}