using dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using negocio;

namespace pokedexMVC.Controllers
{
    public class PokemonController : Controller
    {
        // GET: PokemonController
        public ActionResult Index()
        {
            PokemonNegocio negocio = new PokemonNegocio();
            var pokemonsAct = negocio.listar();
            foreach (Pokemon i in negocio.listar())
            {
                if (!i.Activo)
                {
                    pokemonsAct.Remove(pokemonsAct.Find(p => p.Id == i.Id));
                }
            }
            return View(pokemonsAct);
        }

        // GET: PokemonController/Details/5
        public ActionResult Details(int id)
        {
            PokemonNegocio negocioPokemon = new PokemonNegocio();

            var pokemon = negocioPokemon.listar().Find(p => p.Id == id);
            return View(pokemon);
        }

        // GET: PokemonController/Create
        public ActionResult Create()
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            ViewBag.Elementos = new SelectList(negocioElemento.listar(), "Id", "Descripcion");
            return View();
        }

        // POST: PokemonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pokemon pokemon)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.agregar(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Edit/5
        public ActionResult Edit(int id)
        {
            ElementoNegocio negocioElemento = new ElementoNegocio();
            PokemonNegocio negocioPokemon = new PokemonNegocio();

            var pokemon = negocioPokemon.listar().Find(p => p.Id == id);

            var lista = negocioElemento.listar();
            ViewBag.Tipos = new SelectList(lista, "Id", "Descripcion", pokemon.Tipo.Id);
            ViewBag.Debilidades = new SelectList(lista, "Id", "Descripcion", pokemon.Debilidad.Id);
            return View(pokemon);
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pokemon pokemon)
        {
            PokemonNegocio negocioPokemon = new PokemonNegocio();
            try
            {
                negocioPokemon.modificar(pokemon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Delete/5
        public ActionResult Delete(int id)
        {
            PokemonNegocio negocioPokemon = new PokemonNegocio();

            var pokemon = negocioPokemon.listar().Find(p => p.Id == id);
            return View(pokemon);
        }

        // POST: PokemonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                PokemonNegocio negocioPokemon = new PokemonNegocio();
                negocioPokemon.eliminar(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
