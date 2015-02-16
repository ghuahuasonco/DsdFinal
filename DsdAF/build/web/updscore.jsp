<%@page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>    
<%
    int idstp = 0;
    String idsc=request.getParameter("idsc");
    if(idsc !=null && !idsc.isEmpty())
    idstp=Integer.parseInt(idsc.trim());

    Double idscore = 0.0;
    String scores=request.getParameter("score");
    if(scores !=null && !scores.isEmpty())
    idscore=Double.parseDouble(scores.trim());
   
    try {
        /*
	org.tempuri.Mensajes service = new org.tempuri.Mensajes();
	org.tempuri.IMensajes port = service.getBasicHttpBindingIMensajes();
	 // TODO initialize WS operation arguments here
	java.lang.Integer trainig = idstp; //Integer.valueOf(0);
	java.lang.Double score = idscore; //Double.valueOf(0.0d);
	// TODO process result here
	java.lang.String result = port.updCalificarTProgram(trainig, score);
	out.print(result);
                
        
 	org.tempuri.TPCalificarNotas service = new org.tempuri.TPCalificarNotas();
	org.tempuri.ITPCalificarNotas port = service.getBasicHttpBindingITPCalificarNotas();
	java.lang.Integer trainig = idstp;
	java.lang.Double score = idscore;
	java.lang.String result = port.calificarNotaTP(trainig, score);
	out.print(result);

	DsdAFNota.TPCalificarNotas service = new DsdAFNota.TPCalificarNotas();
	DsdAFNota.ITPCalificarNotas port = service.getBasicHttpBindingITPCalificarNotas();
	java.lang.Integer trainig = idstp;
	java.lang.Double score = idscore;
	java.lang.String result = port.calificarNotaTP(trainig, score);
	out.println(result);
        */
        
	DsdAFScore.TPCalificarNotas service = new DsdAFScore.TPCalificarNotas();
	DsdAFScore.ITPCalificarNotas port = service.getBasicHttpBindingITPCalificarNotas();
	java.lang.Integer trainig = idstp;
	java.lang.Double score = idscore;
	java.lang.String result = port.calificarNotaTP(trainig, score);
	out.println(result);
        
    } catch (Exception ex) {
        String error = ex.getMessage();
        out.print("Parece que hay un problema con el servidor, lo siento por las molestias. Deberíamos estar de vuelta en breve.");    
    }
%>
