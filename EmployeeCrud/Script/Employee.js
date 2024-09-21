
var myData;
$(function () {
    var dataSource = new kendo.data.DataSource({
      /* autoSync: true,*/
        transport: {
           
            read: {
                url: "Employee/lIST",
                /*url: 'api/EmpAPIController/GetEmp',*/
                type: "GET",
                dataType: "json"
            },
            update: {
/*                url: function (data) { return "../Employee/UpdateRecord/" + data; },*/
                url:"Employee/UpdateRecord",
                type: "post",
                dataType: "json"
            },
            destroy: {
/*                url: function(data) { return "../Employee/DeleteRecord/" + data.id; },*/
                url: "../Employee/DeleteRecord",
                type: "POST",
                dataType: "json"
            },
            create: {
               /* url: function (data) { return "Employee/InsertNewRecord/"+data; },*/
                url: "Employee/InsertNewRecord",

                type: "POST",
                dataType: "json"
            },
            parameterMap: function (data, type) {
                if (type == "create") {

                    console.log(data.models[0]);

                    return { models: data.models[0] };
                }
                else if (type == "update") {
                    console.log(data.models[0]);

                    return { models: data.models[0] };
                }
                else if (type == "destroy") { 

                    return { id: data.models[0].id };
                }
               

            }
            
        },
        batch: true,

        schema: {
            model: {
                id: "id",
                fields: {
                    id: {
                        editable: false,
                        nullable: true,
                        type: "number"
                    },
                    name: {
                        type: "string",
                        editable: true,
                    },
                    email: {
                        type: "string",
                       
                    },
                    phone: {
                        type: "string",
                     
                    },
                    city: {
                        type: "string",
                       
                    },
                    gender: {
                        type: "string",
                       
                    }
                }
            }
        }
        
    })

    $("#grid").kendoGrid({
        dataSource: dataSource,
        toolbar: ["create"],
        height: 680,
        /*editable: "inline",*/
       
        pageable: true,
        columns: [
            {
                field: "id",
                title: "id",
                


               /* width: "100px"*/
            },
            {
                field: "name",
                title: "name",
                
               /* width: "100px"*/
            },
            {
                field: "email",
                title: "email",
               
                /*width: "100px"*/
            },
            {
                field: "phone",
                title: "phone",
              
                /*width: "100px"*/
            },
            {
                field: "city",
                title: "city",
               
               /* width: "100px"*/
            },
            {
                field: "gender",
                title: "gender",
               
                /*width: "100px"*/
            },
            {
                command: ["destroy","edit"],
                title:"&nbsp;"
            }
            
        ],
        /* editable: "incell",*/
        editable: "inline",
       
       
    })
    var myGrid = $("#grid");
   
})
$('#exportbtn').click(function () {
    let name = prompt("Excel name");
    $.ajax({
        url:"Employee/ExportToExcel",
        type: "POST",
        data: { name: name },
        sucess: function (data) {
            alert("succss")
        },
        error: function (error) {
            console.log(error);
        }
    })
});
