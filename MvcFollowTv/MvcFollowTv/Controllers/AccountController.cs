﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Domain.DomainEntity;
using Domain.DomainLogin;
using System.Web.Helpers;
using MvcFollowTv.Secure;
using System.IO;
using System.Security.Principal;

namespace MvcFollowTv.Controllers
{
    public class AccountController : Controller
    {
        private UserLogic _userLogic = new UserLogic();
        //
        // GET: /Account/

        public ActionResult LogOn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User u = _userLogic.GetByNickName(user.Nickname);
                if (u != null && u.Password == user.Password)
                {
                    //create ticket
                    FormsAuthentication.SetAuthCookie(user.Nickname, false);
                    return RedirectToAction("Index", "Programs"); // mostra a view com a lista de programas
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect");
                    return View(); // retorna para a mesma view com o campo password assinalado

                }

            }
            return View();
        }


        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
           
            return RedirectToAction("Index", "Programs");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {

            if (ModelState.IsValid)
            {
                User u = _userLogic.GetByNickName(user.Nickname);
                if (u == null)
                {
                    try
                    {
                        WebMail.SmtpServer = "smtp.gmail.com";
                        WebMail.SmtpPort = 587;
                        WebMail.EnableSsl = true;
                        WebMail.UserName = "pi.g15n";
                        WebMail.Password = "12345poiuy";
                        WebMail.From = "pi.g15n@gmail.com";

                        string hash = Hash64.base64Encode(user.getActivatedCode());
                        string usr = Hash64.base64Encode(user.Nickname);
                        WebMail.Send(user.Email, "Activação de Acesso",
                                    string.Format("Para activar o seu acesso siga o seguinte link: <a href='{0}/Account/Activate?u={1}&hash={2}'>{0}/Account/Activate?u={1}&hash={2}</a>",
                                    HttpContext.Request.Headers["host"].Split(':')[0], usr, hash)); // o slip é por causa do apphb meter a porta e depois não funca

                        TempData["message"] = "Registo criado com sucesso! Verifique a sua caixa de correio electrónico.";


                        //Adicionar o user ao repository
                        user.Role = new[] { "hold" };
                        _userLogic.Add(user);

                        return View("UserRegisterOK");
                    }
                    catch (Exception ex)
                    {
                        Response.StatusCode = 401;//not authenticated
                        TempData["message"] = "O envio de Email falhou.{0}" + ex;
                        return View("UserRegisterNotOK");
                    }
                }
                {
                    Response.StatusCode = 401;//not authenticated
                    return View();
                }

            }

            return View();
        }

        public ActionResult Activate(string u, string hash)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    u = Hash64.base64Decode(u);
                    hash = Hash64.base64Decode(hash);

                    User usr = _userLogic.GetByNickName(u);

                    if (usr != null && usr.activate(hash))
                    {
                        usr.Role = new[] { "User" };
                        TempData["activado"] = "Utilizador activado com sucesso!";
                        return RedirectToAction("LogOn");
                    }
                    {
                        return RedirectToAction("Index", "Programs");
                    }
                }
                catch (ApplicationException e)
                {

                    TempData["exception"] = e.Message;
                    return RedirectToAction("Index", "v");

                }
            }
            {
                return RedirectToAction("Index", "Programs");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Admin()
        {
            return View(_userLogic.GetAll());
        }

        [Authorize]
        public ActionResult Edit(String nickname)
        {
            User u = _userLogic.GetByNickName(nickname);
            if (u != null)
            {
               // ViewBag.roles = Models.User.Roles;
                return View(u);
            }
            u = _userLogic.GetByNickName(User.Identity.Name);
            if (u != null)
            {
              //  ViewBag.roles = Models.User.Roles;
                return View(u);
            }
            return RedirectToAction("Admin", "Account");
        }

        [Authorize]
        public ActionResult EditUser(User u)
        {
            return View("Edit");
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditImage(HttpPostedFileBase file)
        {
            User u = _userLogic.GetByNickName(HttpContext.User.Identity.Name);
            // Verify that the user selected a file
            if (file != null && file.ContentLength > 0)
            {
                var pieces = file.FileName.Split('.');
                var extension = pieces.Length > 1 ? pieces[pieces.Length - 1] : string.Empty;
                String fileName = u.Nickname + "." + extension;
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                u.Image = Url.Content(Path.Combine("~/uploads/", fileName));
                file.SaveAs(path);
            }
            return Redirect("Edit");
        }

        [Authorize]
        public ActionResult addImg(String Nickname)
        {
            User u = _userLogic.GetByNickName(HttpContext.User.Identity.Name);
            return View(u);
        }

        [Authorize]
        public ActionResult RemoveUser(String Nickname)
        {
            User u = _userLogic.GetByNickName(Nickname);
            if (User.IsInRole("Admin"))
            {
                _userLogic.Remove(u.Nickname);
                return View("UserRemovedOK");
            }
            if (User.Identity.Name == u.Nickname)
            {
                _userLogic.Remove(u.Nickname);
                HttpContext.Response.Cookies["user"].Expires = DateTime.Now;
                System.Web.HttpContext.Current.User = new GenericPrincipal(new GenericIdentity("public"), new[] { "public" });
                return View("UserRemovedOK");
            } // Se se apagou a si proprio logoff
            return View("Error");
        }
    }
}
