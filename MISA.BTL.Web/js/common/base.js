class BaseJS {
    constructor() {
        this.loadData();
        this.initEvents();
    }

    /**
     * Sinh sự kiện
     * CreatedBy: NNSON (1/1/2021)
     * */
    initEvents() {
        // Sự kiện click khi nhấn thêm mới:
        $('#btnAdd').click(function () {
            $('#txtEmployeeCode').val("");
            $('#txtFullName').val("");
            $('#txtDateOfBirth').val(null);
            $('#txtIdentityNumber').val("");
            $('#txtIdentityDate').val(null);
            $('#txtIdentityPlace').val("");
            $('#txtEmail').val("");
            $('#txtPhoneNumber').val("");
            $('#txtPersonalTaxCode').val("");
            $('#txtSalary').val("");
            $('#txtJoinDate').val(null);
            $('#txtWorkStatus').val("");
            // Hiển thị dialog thông tin chi tiết
            dialogAdd.dialog('open');
            $('#btnSave').attr('value', "add");
            $('#btnDelete').css("display", "none");
        })
        // Load lại dữ liệu khi nhấn button refresh
        $('#btnRefresh').click(function () {
            this.loadData();
        }.bind(this))
        // Ẩn dialog khi ấn nút Hủy
        $('#btnCancel').click(function () {
            // Ẩn dialog thông tin chi tiết
            dialogAdd.dialog('close');
        })
        // Ẩn pop-up khi ấn button Không
        $('#btnClose').click(function () {
            // Ẩn dialog thông tin chi tiết
            dialogPopUp.dialog('close');
        })
        // Xóa bản ghi nếu ấn button Có
        $('#btnAccept').click(function () {
            var employee = {
                "EmployeeId": $('.dialog').attr('id'),
                "EmployeeCode": $('#txtEmployeeCode').val(),
                "FullName": $('#txtFullName').val(),
                "DateOfBirth": $('#txtDateOfBirth').val(),
                "PhoneNumber": $('#txtPhoneNumber').val(),
                "Gender": $('#txtGender').find(':selected').val(),
                "Email": $('#txtEmail').val(),
                "PositionId": $('#txtPositionId').find(':selected').val(),
                "IdentityNumber": $('#txtIdentityNumber').val(),
                "IdentityDate": $('#txtIdentityDate').val(),
                "IdentityPlace": $('#txtIdentityPlace').val(),
                "DepartmentId": $('#txtDepartmentId').find(':selected').val(),
                "PersonalTaxCode": $('#txtPersonalTaxCode').val(),
                "Salary": $('#txtSalary').val(),
                "JoinDate": $('#txtJoinDate').val(),
                "WorkStatus": $('#txtWorkStatus').find(':selected').val()
            }
            $.ajax({
                url: "http://localhost:64798/api/Employees",
                method: 'DELETE',
                data: JSON.stringify(employee),
                contentType: 'application/json'
            }).done(function (res) {
                if (res.MISACode == 200) {
                    alert(res.Messenger);
                }
                dialogPopUp.dialog('close');
                dialogAdd.dialog('close');
            }).fail(function (res) {
                alert(res.responseJSON.Messenger);
            })
            this.loadData();
        }.bind(this))
        // Hiển thị pop-up khi nhấn button Xóa
        $('#btnDelete').click(function () {
            dialogPopUp.dialog('open');
        })
        // Thực hiện lưu dữ liệu khi nhấn button Lưu
        $('#btnSave').click(function () {
            // validate dữ liệu:
            var inputValidates = $('input[required], input[type="email"]');
            $.each(inputValidates, function (index, input) {
                $(input).trigger('blur');
            })
            var inputNotValids = $('input[validate="false"]');
            if (inputNotValids && inputNotValids.length > 0) {
                alert("Dữ liệu không hợp lệ, vui lòng kiểm tra lại");
                inputNotValids[0].focus();
                return;
            }
            // thu thập thông tin dữ liệu -> build thành object
            var employee = {
                "EmployeeCode": $('#txtEmployeeCode').val(),
                "FullName": $('#txtFullName').val(),
                "DateOfBirth": $('#txtDateOfBirth').val(),
                "PhoneNumber": $('#txtPhoneNumber').val(),
                "Gender": $('#txtGender').find(':selected').val(),
                "Email": $('#txtEmail').val(),
                "PositionId": $('#txtPositionId').find(':selected').val(),
                "IdentityNumber": $('#txtIdentityNumber').val(),
                "IdentityDate": $('#txtIdentityDate').val(),
                "IdentityPlace": $('#txtIdentityPlace').val(),
                "DepartmentId": $('#txtDepartmentId').find(':selected').val(),
                "PersonalTaxCode": $('#txtPersonalTaxCode').val(),
                "Salary": $('#txtSalary').val(),
                "JoinDate": $('#txtJoinDate').val(),
                "WorkStatus": $('#txtWorkStatus').find(':selected').val()
            }
            // Gọi service lưu dữ liệu
            if ($('#btnSave').attr('value') == "add") {
                $.ajax({
                    url: "http://localhost:64798/api/Employees",
                    method: 'POST',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    if (res.MISACode == 200) {
                        alert(res.Messenger);
                    }
                    dialogAdd.dialog('close');
                }).fail(function (res) {
                    alert(res.responseJSON.Messenger);
                })
            }
            else if ($('#btnSave').attr('value') == "update") {
                employee.EmployeeId = $('.dialog').attr('id');
                $.ajax({
                    url: "http://localhost:64798/api/Employees",
                    method: 'PUT',
                    data: JSON.stringify(employee),
                    contentType: 'application/json'
                }).done(function (res) {
                    if (res.MISACode == 200) {
                        alert(res.Messenger);
                    }
                    dialogAdd.dialog('close');
                }).fail(function (res) {
                    alert(res.responseJSON.Messenger);
                })
            }
            this.loadData();
        }.bind(this))

        // Hiển thị thông tin chi tiết khi nhấn đúp chuột chọn một bản ghi trên bảng dữ liệu
        $('table tbody').on('dblclick', 'tr', function () {
            dialogAdd.dialog('open');
            $('#btnSave').attr('value', "update");
            $('#btnDelete').css("display", "flex");
            $('.dialog').attr('id', this.id);
            $.ajax({
                url: "http://localhost:64798/api/Employees/" + this.id,
                method: "GET",
            }).done(function (res) {
                $('#txtEmployeeCode').val(res[0].EmployeeCode);
                $('#txtFullName').val(res[0].FullName);
                $('#txtDateOfBirth').val(formatDate2(res[0].DateOfBirth));
                $('#txtGender').val(res[0].Gender);
                $('#txtIdentityNumber').val(res[0].IdentityNumber);
                $('#txtIdentityDate').val(formatDate2(res[0].IdentityDate));
                $('#txtIdentityPlace').val(res[0].IdentityPlace);
                $('#txtEmail').val(res[0].Email);
                $('#txtPhoneNumber').val(res[0].PhoneNumber);
                $('#txtPositionId').val(res[0].PositionId);
                $('#txtDepartmentId').val(res[0].DepartmentId);
                $('#txtPersonalTaxCode').val(res[0].PersonalTaxCode);
                $('#txtSalary').val(res[0].Salary);
                $('#txtJoinDate').val(formatDate2(res[0].JoinDate));
                $('#txtWorkStatus').val(res[0].WorkStatus);
            }).fail(function (res) {
                alert("Không thể load thông tin khách hàng");
            })
        })

        /** 
         * Validate bắt buộc nhập
         * CreatedBy: NNSON (1/1/2021)
         */
        $('input[required]').blur(function () {
            // Kiểm tra dữ liệu đã nhập, nếu để trống thì cảnh báo:
            var value = $(this).val();
            if (!value) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Trường này không được phép để trống');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })

        /**
         * Validate Email đúng định dạng
         * CreatedBy: NNSON (1/1/2021)
         * */
        $('input[type="email"]').blur(function () {
            var value = $(this).val();
            var testEmail = /^[A-Z0-9._%+-]+@([A-Z0-9-]+\.)+[A-Z]{2,4}$/i;
            if (!testEmail.test(value)) {
                $(this).addClass('border-red');
                $(this).attr('title', 'Email không đúng định dạng');
                $(this).attr('validate', false);
            } else {
                $(this).removeClass('border-red');
                $(this).attr('validate', true);
            }
        })
    }

    /**
    * Load dữ liệu
    * CreatedBy: NNSON (29/12/2020)
    */
    loadData() {
        $('table tbody tr').remove();
        // Lấy thông tin các cột dữ liệu
        var ths = $('table thead th');
        // Lấy thông tin dũ liệu sẽ map tương ứng với các cột
        $.ajax({
            url: "http://localhost:64798/api/Employees",
            method: "GET",
        }).done(function (res) {
            $.each(res, function (index, obj) {
                var tr = $(`<tr></tr>`);
                tr.attr('id', obj['EmployeeId']);
                $.each(ths, function (index, th) {
                    var td = $(`<td></td>`);
                    var fieldName = $(th).attr('fieldName');
                    var formatType = $(th).attr('formatType');
                    var value = obj[fieldName];
                    switch (formatType) {
                        case "Date":
                            value = formatDate(value);
                            td.addClass('text-align-center');
                            break;
                        case "Money":
                            td.addClass('text-align-right');
                            value = formatMoney(value);
                            break;
                        case "Gender":
                            value = getGenderName(value);
                            break;
                        case "Status":
                            value = getWorkStatusName(value);
                            break;
                        default:
                            break;
                    }
                    $(td).attr('title', value);
                    
                    td.append(value);
                    $(tr).append(td);
                })
                $('table tbody').append(tr);
            })
        }).fail(function (res) {

        })
    }
}