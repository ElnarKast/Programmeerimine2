﻿using KooliProjekt.Controllers;
using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KooliProjekt.UnitTests.ControllerTests
{
    public class PanelMaterialsControllerTests
    {
        private readonly Mock<IPanelMaterialsService> _panelmaterialsServiceMock;
        private readonly PanelMaterialsController _controller;

        public PanelMaterialsControllerTests()
        {
            _panelmaterialsServiceMock = new Mock<IPanelMaterialsService>();
            _controller = new PanelMaterialsController(_panelmaterialsServiceMock.Object);
        }

        [Fact]
        public async Task Index_should_return_view_and_data()
        {
            // Arrange
            var page = 1;
            var data = new List<PanelMaterial>
            {
                new PanelMaterial { Id = 1, Title = "Test 1" },
                new PanelMaterial { Id = 2, Title = "Test 2" }
            };
            var pagedResult = new PagedResult<PanelMaterial>
            {
                Results = data,
                CurrentPage = 1,
                PageCount = 1,
                PageSize = 5,
                RowCount = 2
            };
            _panelmaterialsServiceMock
                .Setup(x => x.List(page, It.IsAny<int>()))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.Index(page) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Index"
            );
            Assert.Equal(pagedResult, result.Model);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_null()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_item_was_not_found()
        {
            // Arrange
            int? id = 1;
            var PanelMaterial = (PanelMaterial)null;
            _panelmaterialsServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(PanelMaterial);

            // Act
            var result = await _controller.Details(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Details_should_return_correct_view_with_model_when_item_was_found()
        {
            // Arrange
            int? id = 1;
            var PanelMaterial = new PanelMaterial { Id = id.Value, Title = "Test 1" };
            _panelmaterialsServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(PanelMaterial);

            // Act
            var result = await _controller.Details(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Details"
            );
            Assert.Equal(PanelMaterial, result.Model);
        }

        [Fact]
        public void Create_should_return_correct_view()
        {
            // Arrange

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Create"
            );
        }

        [Fact]
        public async Task Delete_should_return_notfound_when_id_is_null()
        {
            // Arrange
            int? id = null;

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_notfound_when_item_was_not_found()
        {
            // Arrange
            int? id = 1;
            var PanelMaterial = (PanelMaterial)null;
            _panelmaterialsServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(PanelMaterial);

            // Act
            var result = await _controller.Delete(id) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Delete_should_return_correct_view_with_model_when_item_was_found()
        {
            // Arrange
            int? id = 1;
            var PanelMaterial = new PanelMaterial { Id = id.Value, Title = "Test 1" };
            _panelmaterialsServiceMock
                .Setup(x => x.Get(id.Value))
                .ReturnsAsync(PanelMaterial);

            // Act
            var result = await _controller.Delete(id) as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.True(
                string.IsNullOrEmpty(result.ViewName) ||
                result.ViewName == "Delete"
            );
            Assert.Equal(PanelMaterial, result.Model);
        }
        [Fact]
        public async Task DeleteConfirmed_should_delete_list()
        {
            // Arrange
            int id = 1;
            _panelmaterialsServiceMock
                .Setup(x => x.Delete(id))
        .Verifiable();

            // Act
            var result = await _controller.DeleteConfirmed(id) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            _panelmaterialsServiceMock.VerifyAll();
        }
    }
}