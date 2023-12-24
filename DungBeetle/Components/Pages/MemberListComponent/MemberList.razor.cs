using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace DungBeetle.Components.Pages.MemberListComponent;

public class MemberInputBase : ComponentBase
{
    protected const string NameElementId = "name";

    [Parameter]
    public List<MemberInfoViewModel> Members { get; set; } = [];

    [Inject]
    public required IJSRuntime Js { get; set; }

    protected WorkMember? Member { get; set; } = new();

    private string? FocusId { get; set; }

    protected void Add()
    {
        var name = Member!.Name;
        if (string.IsNullOrWhiteSpace(name))
        {
            Member = new WorkMember();
            return;
        }
        if (Members.Exists(r => r.Name == name))
        {
            Members.Remove(Members.First(r => r.Name == name));
        }
        Members.Add(new MemberInfoViewModel
        {
            Name = name,
            IgnoreDays = Member.IgnoreDays?.Split(',')
                .Select(int.Parse)
                .ToList() ?? []
        });
        Member = new WorkMember();
        FocusId = NameElementId;
    }

    protected void Clean()
    {
        Members.RemoveAll(_ => true);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (string.IsNullOrWhiteSpace(FocusId) == false)
        {
            await Js.InvokeVoidAsync("setFocusToElement", FocusId);
        }
        FocusId = default;
        await base.OnAfterRenderAsync(firstRender);
    }

    protected void Delete(MemberInfoViewModel member)
    {
        Members.Remove(member);
    }
}
