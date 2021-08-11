/*function ViewTickets(URL)
{
    debugger
    var id = $('#managerId').val();
    $.ajax({
        url: URL+ "?managerID=" + id,
        type: 'GET',
        success: OnSuccess
    });
}*/
$(document).ready(function () {
    //function will be called on button click having id btnsave
    $("#btnView").click(function () {
        $.ajax(
            {
                type: "GET", //HTTP POST Method
                url: "/BuildingManager/GetTickets", // Controller/View
                data: { //Passing data
                     id : $('#managerId').val()
                },
                success: function () {
                    var ticketList = response;
                    list = document.getElementById("EmailList");

                    ticketList.forEach((item) => {
                        li = document.createElement("li");
                        li.innerText = item;
                        list.appendChild(li);
                        location.reload(true);
                    })
                }

            });

    });
});

/*
function OnSuccess(response) {

    var ticketList = response;
    list = document.getElementById("EmailList");

    ticketList.forEach((item) => {
        li = document.createElement("li");
        li.innerText = item;
        list.appendChild(li);
    })
}*/