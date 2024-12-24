using Microsoft.AspNetCore.Mvc;
using REAL_Estate.Components.Security;
using REAL_Estate.Objects;
using REAL_Estate.Services;
using REAL_Estate.Validators;

namespace REAL_Estate.Controllers.Administration;

[Area(nameof(Area.Administration))]
public class Accounts : ValidatedController<AccountValidator, AccountService>
{
    public Accounts(AccountValidator validator, AccountService service)
        : base(validator, service)
    {
    }

    [HttpGet]
    public ViewResult Index()
    {
        return View(Service.GetViews());
    }

    [HttpGet]
    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(AccountCreateView account)
    {
        if (!Validator.CanCreate(account))
            return View(account);

        Service.Create(account);

        Authorization.Refresh(HttpContext.RequestServices);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [AuthorizeAs(nameof(Index))]
    public ActionResult Details(Int64 id)
    {
        return NotEmptyView(Service.Get<AccountView>(id));
    }

    [HttpGet]
    public ActionResult Edit(Int64 id)
    {
        return NotEmptyView(Service.Get<AccountEditView>(id));
    }

    [HttpPost]
    public ActionResult Edit(AccountEditView account)
    {
        if (!Validator.CanEdit(account))
            return View(account);

        Service.Edit(account);

        Authorization.Refresh(HttpContext.RequestServices);

        return RedirectToAction(nameof(Index));
    }
}