﻿namespace Resorter.Application.Features.Users.Dto;

public class LoginDto
{
    public bool Succeeded { get; set; }
    public string Token { get; set; }
    public List<string> Errors { get; set; }
}
