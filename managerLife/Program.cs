using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Models.ContaDb;
using Models.Contas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
        options => {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Manager Home Life", Description = "Manager da Casa como um Todo", Version = "v1"});	
        }
    );

builder.Services.AddDbContext<ContaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Manager Home V1");
    });
}

#region Categoria

app.MapGet("/categoria", async (ContaDbContext context) => {
    return await context.Categoria.ToListAsync();
});

app.MapPost("/categoria", (ContaDbContext context, Categoria categoria) => {
    context.Categoria.Add(categoria);
    var result = context.SaveChanges();

 return result > 0
     ? Results.Created($"/categoria/{categoria.Id}", categoria)
     : Results.BadRequest("Houve um erro no cadastro de Categoria");
});

app.MapGet("/categoria/{id}", async (ContaDbContext context, int id) => {
    return await context.Categoria.FindAsync(id);
});

app.MapPut("/categoria/{id}", async (ContaDbContext context, Categoria categoria, int id) => {
    var model = await context.Categoria.FindAsync(id);
    if (model is null) return Results.NotFound();
    
    model.Nome = categoria.Nome;
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/categoria/{id}", async (ContaDbContext context, int id) => {
    var categoria = await context.Categoria.FindAsync(id);
    if (categoria is null) return Results.NotFound();

    context.Categoria.Remove(categoria);
    await context.SaveChangesAsync();

    return Results.Ok();
});

#endregion

#region Conta
app.MapGet("/conta", async (ContaDbContext context) => {
    return await context.Conta.Include(p => p.Categoria).ToListAsync();
});

app.MapGet("/conta/{id}", async (ContaDbContext context,Guid id) => {
    return await context.Conta.FindAsync(id);
});	

app.MapPost("/conta", (ContaDbContext context, Conta conta) => {
    var categoria = context.Categoria.Find(conta.Categoria.Id);
    conta.Categoria = categoria;

    context.Conta.Add(conta);
    var result = context.SaveChanges();

    return result > 0
     ? Results.Created($"/conta/{conta.Id}", conta)
     : Results.BadRequest("Houve um erro no cadastro de Conta");
});

app.MapPut("/conta/{id}", async (ContaDbContext context, Conta conta, Guid id) => {
    var model = await context.Conta.FindAsync(id);
    if (model is null) return Results.NotFound();

    model.Cobrador = conta.Cobrador;
    model.Total = conta.Total;
    var categoria = context.Categoria.Find(conta.Categoria.Id);
    model.Categoria = categoria;
    model.Observacao = conta.Observacao;
    model.DataCompra = conta.DataCompra;
    
    await context.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/conta/{id}", async (ContaDbContext context, Guid id) => {
    var conta = await context.Conta.FindAsync(id);
    if (conta is null) return Results.NotFound();

    context.Conta.Remove(conta);
    await context.SaveChangesAsync();

    return Results.Ok();
});

// app.MapPost("/files", (object arquvivos) => {
// INTEGRACAO de ARQUIVOS
// });

#endregion

#region UploadArquivos
/*
    INTEGRACAO COM API DE UPLOAD DE ARQUIVOS
*/
#endregion

#region Autenticacao
/*
    INTEGRACAO COM API DE AUTENTICACAO (ha fazer)
*/
#endregion

app.Run();