$(document).ready(function () {
    loadData();
})

/**
 * Load dữ liệu
 * CreatedBy: NNSON (29/12/2020)
 */
function loadData() {
    // Lấy dữ liệu về:
    $.ajax({
        url: "http://api.manhnv.net/api/employees",
        method: "GET",
    }).done(function (res) {
        var data = res;
        $.each(data, function (index, item) {
            var dateOfBirth = item['DateOfBirth'];
            dateOfBirth = formatDate(dateOfBirth);
            var salary = item['Salary'];
            salary = formatMoney(salary);
            var tr = $(` <tr>
                        <td style="max-width: 90px;" title="${item['EmployeeCode']}">${item['EmployeeCode']}</td>
                        <td style="max-width: 120px;" title="${item['FullName']}">${item['FullName']}</td>
                        <td style="max-width: 70px;" title="${item['GenderName']}">${item['GenderName']}</td>
                        <td style="max-width: 100px; text-align: center;" title="${dateOfBirth}">${dateOfBirth}</td>
                        <td style="max-width: 120px;" title="${item['PhoneNumber']}">${item['PhoneNumber']}</td>
                        <td style="max-width: 200px;" title="${item['Email']}">${item['Email'] || ""}</td>
                        <td style="max-width: 80px;" title="${item['PositionName']}">${item['PositionName'] || ""}</td>
                        <td style="max-width: 100px;" title="${item['DepartmentName']}">${item['DepartmentName'] || ""}</td>
                        <td style="max-width: 100px; text-align: right;" title="${salary}">${salary}</td>
                        <td style="max-width: 100px;" title="${item['WorkStatusName']}">${item['WorkStatusName'] }</td>
                    </tr>`);
            $('table tbody').append(tr);
        })
        debugger;
    }).fail(function (res) {

    })
}
