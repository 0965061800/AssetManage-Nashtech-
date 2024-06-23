﻿using AssetManagement.Application.Services.Implementations;
using AssetManagement.Application.Services.Interfaces;
using AssetManagement.Data.Interfaces;
using AssetManagement.Domain.Entities;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.AspNetCore.Identity;
using Moq;

namespace AssetManagement.Application.Tests.Services.AuthenticationTests;
public class SetupAuthenticationServiceTest
{
    protected readonly IFixture _fixture;
    protected IAuthService _authService;
    protected readonly Mock<UserManager<AppUser>> _userManagerMock;
    protected readonly Mock<IJwtTokenGenerator> _tokenGeneratorMock;

    public SetupAuthenticationServiceTest()
    {
        _fixture = new Fixture().Customize(new AutoMoqCustomization());
        _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        _userManagerMock = _fixture.Freeze<Mock<UserManager<AppUser>>>();
        _tokenGeneratorMock = _fixture.Freeze<Mock<IJwtTokenGenerator>>();
        _authService = new AuthService(_userManagerMock.Object, _tokenGeneratorMock.Object);
    }
}
