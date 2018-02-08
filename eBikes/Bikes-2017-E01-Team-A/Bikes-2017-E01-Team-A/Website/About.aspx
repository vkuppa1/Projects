<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
      <div class="row">
        <div class="col-md-4">
            <img src="images/Layer%201@1x.jpg" height="120" width="120"/>
            </div>
          <div class="col-md-4">
     <h3>Professional Programmers Team</h3>
              </div>
                    </div>
     
    <h1>Team Members: -</h1>
     <div class="row">
        <div class="col-md-3">
            <h2>Vivek Singh</h2>
            <p>
                <img src="images/pp.jpg" height="200" width="180" />
            </p>
            
           <table>
              <headerTemplate>
               <tr>
                    
                   <th>Role</th>
                   <th>UserName</th>
                   <th>Password</th>
                   
                  </tr>
               </headerTemplate>

               <ItemTemplate>
               <tr>
                   <td>CEO</td>
                   <td>VSingh27</td>
                   <td>Password123</td>
                </tr>
               </ItemTemplate>
           </table>
        </div>
        <div class="col-md-3">
            <h2>Karan Karan</h2>
            <p>
                <img src="images/karan.jpg" height="200" width="180"/>
            </p>
              <table>
               <tr>

                   <th>Role</th>
                   <th>UserName</th>
                   <th>Password</th>
                  </tr>
               <tr>
                   <td>CEO</td>
                   <td>KKaran1</td>
                   <td>Password123</td>
                </tr>
           
           </table>

        </div>
        <div class="col-md-3">
            <h2>Akshay Bharti</h2>
            <p>
                <img src="images/akshay.jpg" height="200" width="180" />
            </p>
          
              <table>
               <tr>
                   <th>Role</th>
                   <th>UserName</th>
                   <th>Password</th>
                  </tr>
               <tr>
                   <td>CEO</td>
                   <td>Abharti1</td>
                   <td>Password123</td>
                </tr>
           </table>

        </div>

         <div class="col-md-3">
            <h2>Vamsee Kuppa</h2>
            <p>
                <img src="images/vamsee.jpg" height="200" width="180" />
            </p>
          
              <table>
               <tr>
                   <th>Role</th>
                   <th>UserName</th>
                   <th>Password</th>
                  </tr>
               <tr>
                   <td>CEO</td>
                   <td>KKupp1</td>
                   <td>Password123</td>
                </tr>
                  </table>

        </div>
    </div>

   


</asp:Content>
