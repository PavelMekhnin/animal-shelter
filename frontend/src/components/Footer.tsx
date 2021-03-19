import React from "react";

export const Footer : React.FC = () =>(
    <footer className="page-footer grey darken-4">
          <div className="container">
            <div className="row">
              <div className="col l6 s12">
                <h5 className="white-text">About</h5>
                <p className="grey-text text-lighten-4">This social project was developed by volunteers only without any financial support.</p>
              </div>
              <div className="col l4 offset-l2 s12">
                <h5 className="white-text">Contacts</h5>
                <ul>
                  <li><a href="mailto:pavel.mekhnin@gmail.com"><span className="grey-text text-lighten-3" >pavel.mekhnin@gmail.com</span></a></li>
                  <li><span className="grey-text text-lighten-3" >@pavelmekhnin</span></li>
                </ul>
              </div>
            </div>
          </div>
          <div className="footer-copyright">
            <div className="container">
            © 2021 Copyright "Pavel Mekhnin"
            </div>
          </div>
        </footer>
)