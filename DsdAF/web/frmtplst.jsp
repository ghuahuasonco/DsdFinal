<%@page contentType="text/html" pageEncoding="UTF-8"%>
<% 
    String pathweb  = request.getContextPath()+"/";
%>

 <script>
var urlObj = "http://localhost:1266/TPrograms.svc/TPrograms";
$.ajax({
    type:'GET',
    url:urlObj,
    contentType: "application/json", 
    success:function(data) {
    alert("success");
    
    },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr +" "+ajaxOptions+" "+thrownError);
            }
});
</script>




<div class="panel panel-primary">
<div class="panel-heading">Training Program</div>
<div class="panel-body">
<table class="table table-hover">
<thead>
<tr>
<th><small>Nro</small></th>
<th><small>Training Program</small></th>
<th><small>Fecha Inicio y Fin</small></th>
<th></th>
</tr>
</thead>
<tbody>
<div id="TPResumen" name="TPResumen"></div>    
</tbody>
</table>      
<a href="<%=pathweb%>index.jsp?opc=1" class="btn btn-primary btn-sm" role="button">
&nbsp;&nbsp;&nbsp;Salir&nbsp;&nbsp;&nbsp;
</a>
</div></div>                      