// See https://aka.ms/new-console-template for more information
using SLG.Aplicacion;
using SLG.Repositorios;

using var context = new SLGContext();

context.Add(new Expediente("pene"));
context.Add(new Tramite(1,"pijita"));
context.SaveChanges(); 