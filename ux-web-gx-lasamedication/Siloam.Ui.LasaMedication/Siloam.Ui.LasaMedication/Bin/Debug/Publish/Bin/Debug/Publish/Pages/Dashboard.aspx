<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeFile="Dashboard.aspx.cs" Inherits="Pages_Dashboard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="DashboardContent" runat="server">

    <!DOCTYPE html>

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head >
        <style>
            .text1 {
                font-family: 'Helvetica Neue LT Std';
                font-size: 14px;
                font-weight: bold;
            }

            .bgTable {
                background: #F0F1F7 0% 0% no-repeat padding-box;
                opacity: 1;
            }

            table.dataTable tbody {
                font-weight: normal;
                /*font-style: 12px;*/
            }

            .dataTables_wrapper .dataTables_paginate .paginate_button.current, .dataTables_wrapper .dataTables_paginate .paginate_button.current {
                /* border: 0 !important;
                background: #1D2567 0% 0% no-repeat padding-box !important;
                color: white !important;*/
                border: 0 !important;
                background: #1D2567 0% 0% no-repeat padding-box !important;
                color: white !important;
                text-align: center;
                margin: auto;
                width: auto;
                height: 40px !important;
                margin-left: 2px;
            }

            .dataTables_wrapper .dataTables_paginate .paginate_button {
                padding: 1px;
                border-radius: 0px !important;
            }
                .dataTables_wrapper .dataTables_paginate .paginate_button:hover {
                    background: #1D2567;
                    color: white !important;
                    height: 40px;
                    width: 24px !important;
                }
            table.dataTable.no-footer{
            border-bottom:1px solid #ddd;
            }

            .judulContent {
                font-size: 22px;
                font-family: 'Helvetica Neue LT Std';
                font-weight: bold;
            }

            .textCenter1 {
/*                top: 399px;
                left: 878px;*/
                width: 76px;
                height: 25px;
                padding-bottom: 2px;
                /*font-size: 12px;*/
                /* UI Properties */
/*                background: #4D9B35 0% 0% no-repeat padding-box;
                border-radius: 2px;
                opacity: 1;
                border-radius: 2px;*/
            }

            .btn-map{
                font-size: 12px;
                padding-bottom: 2.5px;
                padding-top: 2.5px;
                width: 76px;
            }

            .editColor {
                color: #2A3593;
                font-size: 12px;
                padding-left: 23px;
                font-family: 'Helvetica Neue LT Std';
                font-weight: bold;
            }

            .lasaMargin {
                padding-left: 20px;
            }

            .mapsButton {
                width: 76px;
                height: 25px;
                padding-bottom: 10px;
                color: white;
            }


            .dataTables_wrapper .dataTables_paginate .paginate_button.current, .dataTables_wrapper .dataTables_paginate .paginate_button.current:hover {
                border: 0 !important;
                background: #1D2567 0% 0% no-repeat padding-box !important;
                color: white !important;
                width: 24px !important;
                
            }
        </style>
        <title></title>
    </head>
    <body>
        <div id="box1" class="text1">
            <div class="card shadow mt-3 mr-3" style="padding-left: 15px; padding-right: 15px; padding-top: 20px;">
            <div class="judulContent contentResponsive mt-3" style="padding-bottom: 10px; position: absolute;">
                LASA MEDICATION LIST
            </div>
            <div class="table-responsive mt-2">
          <%--<asp:Label runat="server" ID="UserId" ></asp:Label>--%>
                <table class="table row-border" id="tableMed">

                    <thead class="bgTable">
                        <tr class="text-center">
                            <th>Drug Name</th>
                            <th>Description</th>
                            <th>Last Modified</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                </table>
            </div>
        </div>
    </div>

        <%--Modals--%>
        <div class="modal fade" id="mapsModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" style="width: 408px; height: 264px;" role="document">
                <div class="modal-content px-3 py-2">
                    <div class="modal-header" style="border: 0;">
                        <h5 class="modal-title font-weight-bold" id="exampleModalCenterTitle" style="font: normal normal bold 18px/16px Helvetica; margin-top: 4px">LASA MEDICATION LIST</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <%--<span aria-hidden="true">&times;</span>--%>
                            <i class="fa-solid fa-xmark"></i>
                        </button>
                    </div>
                    <div class="modal-body">
                        <input type="text" id="salesItemId" name="name" value="" hidden />
                            <asp:Label runat="server" ID="UserId" hidden ></asp:Label>

                            <%--<asp:Label runat="server" ID="Label1" hidden></asp:Label>--%>
                        <table>
                            <tr>
                                <td width="100px">Drug Name</td>
                                <td width="20px">:</td>
                                <td id="drugName"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td height="50px">Is Lasa?</td>
                                <td>:</td>
                                <td>
                                    <input class="radioInput" type="radio" name="IsLasa" value="1" />
                                    <label id="yes">Yes</label>
                                    <input class="radioInput" type="radio" name="IsLasa" value="0" style="margin-left: 8px;"/>
                                    <label id="no">No</label>
                                </td>
                            </tr>
                            <tr id="dateLasa">
                                <td height="20px">Last Modified</td>
                                <td>:</td>
                                <td id="modifiedDate"></td>
                                <%--<td>17.00</td>--%>
                            </tr>

                        </table>
                    </div>
                    <div class="modal-footer" style="border: 0;">
                        <button type="button" id="saveButton" class="btn btn-primary" onclick="Save()" data-dismiss="modal">Save</button>
                    </div>
                </div>
            </div>
        </div>
      
        <%--<p style="color: black; font-weight: bold; font-size: 20px;">HELLO WORLD</p>--%>
    </body>

    <script>
        /*================================Show Data Table================================*/
        var table = "";
        $(document).ready(function () {
            console.log("Berhasil");
            table = $('#tableMed').dataTable({
                "bPaginate": true,
                "stateSave": true,
                "scrollX" : true,
                "bLengthChange": false,
                "bFilter": true,
                "bInfo": true,
                "bSort": false,
                "bAutoWidth": false,
                "oLanguage": {
                    "sSearch": "",
                },
                "language": {
                    "searchPlaceholder": "🔍 Search By Drug Name",
                    "info": "Result: _END_ of _TOTAL_ ",
                    "infoEmpty": "Result 0 of 0 entries",
                    "paginate": {
                        "next": `<svg class="SVGInline-svg" id="S_NavRight_S_22" viewBox="0 0 22 22" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns: xlink="http://www.w3.org/1999/xlink" xml: space="preserve" x="0px" y="0px" width="22px" height="22px" >
                            <g id="Layer%201">
                                <path d="M 14.4775 10.3975 L 9.2876 5.2178 C 8.9878 4.9277 8.5176 4.9277 8.2178 5.2178 C 7.9277 5.5078 7.9277 5.9775 8.2178 6.2778 L 12.8779 10.9277 L 8.2178 15.5879 C 7.9277 15.8779 7.9277 16.3477 8.2178 16.6475 C 8.5176 16.9277 8.9878 16.9277 9.2876 16.6475 L 14.4678 11.4575 C 14.7578 11.1577 14.7578 10.6875 14.4775 10.3975 L 14.4775 10.3975 Z" fill="#707070"></path>
                            </g>
                        </svg>`,
                        "previous": `<svg class="SVGInline-svg" id="S_NavLeft_S_22" viewBox="0 0 22 22" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xml:space="preserve" x="0px" y="0px" width="22px" height="22px">
                            <g id="Layer%201">
                                <path d="M 7.2092 10.3975 L 12.3992 5.2178 C 12.699 4.9277 13.1692 4.9277 13.469 5.2178 C 13.759 5.5078 13.759 5.9775 13.469 6.2778 L 8.8089 10.9277 L 13.469 15.5879 C 13.759 15.8779 13.759 16.3477 13.469 16.6475 C 13.1692 16.9277 12.699 16.9277 12.3992 16.6475 L 7.219 11.4575 C 6.929 11.1577 6.929 10.6875 7.2092 10.3975 L 7.2092 10.3975 Z" fill="#707070"></path>
                            </g>
                        </svg>`
                    }
                },
                'ajax': {
                    'url': "http://localhost:8080/getAllDataLasa",
                    'dataType': 'json',
                    'dataSrc': 'data'
                },
                'columns': [
                    {
                        'data': 'name',
                        
                    },
                    {
                        'data': null,
                        'addClass': 'lasaMargin',
                        'render': (data) => {
                            if (data.isLasa == 0) {

                                return "-";
                            } else {
                                    return "LASA";
                                }
                             
                        }
                    },

                    {
                        'data': null,
                        render: (data, type, row) => {

                            if (row['lasaId'] != 0) {
                                //console.log("Waktu: ");
                                return toDate(row['modified']) + " - " + toTime(row['modified']);
                            }
                        else {
                                return "-";
                            }
                            //if (data.modified == "01/01/0001 - 00:00") {
                            //    return "-";
                            //}
                            //else {
                            //    return data.modified;
                            //}
                      }
                    },
                    {
                        'data': null,
                        'className': 'text-center',
                        'render': (data, type, row) => {
                            if (data.lasaId == 0) {
                                return `<div class="btn btn-success mapsButton" style="cursor:pointer; font-size:12px; padding-top: 3px; padding-bottom: 3px;" data-toggle="modal" data-target="#mapsModal" onclick="ShowMaps('${row["salesItemId"]}')">MAP</div>`;

                            } else {
                                return `<a href="#" class="editColor" data-toggle="modal" data-target="#mapsModal" onclick="ShowEdit('${row["salesItemId"]}')" >EDIT</a>`
                            }
                        },
                        "className": "textCenter1",
                    },
                   
                ]
            });
            $('.dataTables_filter input[type="search"]').css(
                { 'width': '373px', 'display': 'inline-block', 'font-family': `'Helvetica', FontAwesome, sans-serif`, 'font-size': '14px' }
            ).prop("class", "SearchInput");
            $('.dataTables_info').css(
                { 'text-align': 'left', 'font': 'normal normal normal 12px / 17px Helvetica', 'letter-spacing': '0.38px', 'color': '#9B9898', 'margin-top': '32.51px', 'margin-left': '18.5px', 'margin-bottom': '47.14px' }
            );
            //$('.dataTables_info').replaceWith("Result: 0 of 100");
       

            console.log(table);
        });

        function toDate(sqlDateTime) {
            const myArray = sqlDateTime.split("T");
            //const myArray = sqlDateTime.split("T");
            let date = myArray[0].split("-");
            let modifiedDate = date[2] + '/' + date[1] + '/' + date[0];
            return modifiedDate;
        }

        function toTime(sqlDateTime) {
            const myArray = sqlDateTime.split("T");
            let time = myArray[1].split(":");
            let modifiedTime = time[0] + ":" + time[1];
            return modifiedTime;
        }

        function ShowMaps(salesItemId) {
            $.ajax({
                url: "http://localhost:8080/getLasaById/" + salesItemId,
                dataSrc: 'data'
            }).done((result) => {
                $("#dateLasa").prop("hidden", true);
                $("#salesItemId").val(salesItemId);
                $("#drugName").html(result.data[0].name);
                $("#modifiedDate").html(result.data[0].modified);
                if (result.data[0].isLasa == false) {
                    $("#no").prop("checked", true);
                } else {
                    $("#yes").prop("checked", true);
                }
                console.log(result);
            }).fail((error) => {
                console.log(error);
            });
            //$("#dateLasa").prop("hidden", true);
        }

        function ShowEdit(salesItemId) {
            $.ajax({
                url: "http://localhost:8080/getLasaById/" + salesItemId,
                dataSrc: 'data'
            }).done((result) => {
                $("#dateLasa").prop("hidden", false);
                $("#drugName").html(result.data[0].name);
                $("#salesItemId").val(salesItemId);
                $("#modifiedDate").html(result.data[0].modified);

                console.log(result);

            }).fail((error) => {
                console.log(error)
            });
            //$("#dateLasa").prop("hidden", false);
        }

        if (window.matchMedia("(max-width: 570px)").matches) {
            $(".contentResponsive").prop("style", "position:static !important; font-size:14px");
            $(".SearchInput").prop("style", "width:165px!important; font-size:12px");
        }


        //Post Lasa
        function Save() {
            var obj = new Object(); //sesuaikan sendiri nama objectnya dan beserta isinya
            //ini ngambil value dari tiap inputan di form nya
            obj.inputSalesItemId = parseInt($("#salesItemId").val());
            obj.inputUserId = parseInt($("#DashboardContent_UserId").html());
            obj.inputIsLasa = parseInt($("input[name='IsLasa']:checked").val());
            //console.log(obj);
            const myJSON = JSON.stringify(obj);
            console.log(myJSON);
            $.ajax({
                url: "http://localhost:8080/PostLasa",
                contentType: "application/json;charset=utf-8",
                type: "POST",
                data: myJSON
            }).done((result) => {
                //buat alert pemberitahuan jika success
                console.log(result);
                //alert(result.message);
                var ikon;
                var pesan;
                if (result.code == 200) {
                    ikon = 'success';
                    pesan = 'Success';
                }
                else {
                    ikon = 'error';
                    pesan = 'Error';
                }
                Swal.fire({
                    icon: ikon,
                    title: pesan,
                    text: result.data[0].message
                });
                
                //reload tabel
                let table = $('#tableMed').DataTable(null, false);
                table.ajax.reload();
                $('#mapsModal').modal('hide');
            }).fail((error) => {
                console.log(error);
                Swal.fire({
                    icon: 'error',
                    title: 'Oops...',
                    text: 'Field Cannot be Empty!'
                    //text: error.statusText
                })
            })
        }
    </script>

    </html>
</asp:Content>

