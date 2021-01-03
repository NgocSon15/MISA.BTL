$(document).ready(function () {
    dialogAdd = $('.info-dialog').dialog({
        autoOpen: false,
        width: 700,
        modal: true,
        resizable: true,
        fluid: true,
    });
    dialogPopUp = $('.pop-up').dialog({
        autoOpen: false,
        width: 400,
        modal: true,
    })
    new EmployeeJS();

})

/**
 * Class quản lý các sự kiện cho trang Employee
 * CreatedBy: NNSON (29/12/2020)
 * */
class EmployeeJS extends BaseJS{
    constructor() {
        super();
    }
}

