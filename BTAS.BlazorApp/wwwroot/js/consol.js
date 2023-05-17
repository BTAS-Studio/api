var consolGrid;

function DoTest() {
    return false;
}

function renderjQueryComponents() {
    $('.select2').select2();
}

function initDataTable(t) {
    $(document).ready(function () {
        consolGrid = $(t).DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": true,
            "responsive": true,
        });

        consolGrid.DataTable();
    });
}

function clearDataTable(t) {
    $(document).ready(function () {
        $(t).DataTable().destroy();
    });
}

window.getTitle = () => {
    return document.title;
};

