//function ViewTickets(URL)
//{
  //  debugger
    //var id = $('#managerId').val();
  //  $.ajax({
  //      url: URL+ "?managerID=" + id,
  //      type: 'GET',
   //     success: OnSuccess
  //  });
//}



function OnSuccess(response) {

    var ticketList = response;
    list = document.getElementById("EmailList");

    ticketList.forEach((item) => {
        li = document.createElement("li");
        li.innerText = item;
        list.appendChild(li);
    })
}