﻿using Example.EntityFramework.Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Example.EntityFramework.Infrastructure.EntityFramework;

public class UnitOfWork<T> : IUnitOfWork where T : DbContext
{
    private readonly T _context;

    public UnitOfWork(T context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}
