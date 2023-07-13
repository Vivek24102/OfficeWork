$(document).ready(function () {
    $("table").DataTable();
    debugger;
    getAllEmployee();
});


function getAllEmployee() {

    $.ajax({
        url: `/Employee/GetEmployee`,
        method: "get",
        contentType: "application/json",
        //async: false,
        success: function (res) {
            console.log(res)
            $("tbody").html('');
            res.forEach((ele) => {
                $("tbody").append(`<tr>
                <td>${ele.employeeName}</td>
                <td>${ele.emailid}</td>
                <td>${ele.contactNo}</td>
                <td>${ele.empAddress}</td>
                <td>${ele.department.deptName}</td>
                <td><a class="btn btn-primary" href="/Employee/AddEdit/${ele.emplooyeid}">Edit</a></td>
                <td><a class="btn btn-danger" onclick="return confirm('Are you sure you want to delete?');" href="/Employee/delete/${ele.emplooyeid}">Delete</a></td>

                    </tr>`)
            })

        }
    });
}

