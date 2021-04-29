using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eniModule5Tp1.Models;

namespace eniModule5Tp1.Controllers
{
    public class ChatController : Controller
    {
        private readonly static List<Chat> chats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(chats);
        }

        // Chat/Details/id
        public ActionResult Details(int id)
        {
            // On récupère le chat qui correspond l'id
            // FirstOrDefault permet de récupérer un seul objet, si rien, renvoit null
            // Mais s'il y a plusieurs cela lève une exception
            return View(chats.FirstOrDefault(x => x.Id == id));
        }

        
        public ActionResult Delete(int id)
        {
            // On récupère le chat
            return View(chats.FirstOrDefault(x => x.Id == id));
        }

        // La méthode qui correspond au Post de cette route, indispensable
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // On supprime, fin on le relâche sinon c'est bien trop cruel, le chat qui correspond l'id
                chats.Remove(chats.FirstOrDefault(x => x.Id == id));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}