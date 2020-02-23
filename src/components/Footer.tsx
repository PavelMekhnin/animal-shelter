import React from "react";

export const Footer : React.FC = () =>(
    <footer className="page-footer grey darken-3">
          <div className="container">
            <div className="row">
              <div className="col l6 s12">
                <h5 className="white-text">More</h5>
                <p className="grey-text text-lighten-4">This social project was developed by volunteers only without any financial support.</p>
              </div>
              <div className="col l4 offset-l2 s12">
                <h5 className="white-text">Links</h5>
                <ul>
                  <li><a className="grey-text text-lighten-3" href="#!">Contacts</a></li>
                  <li><a className="grey-text text-lighten-3" href="#!">About</a></li>
                </ul>
              </div>
            </div>
          </div>
          <div className="footer-copyright">
            <div className="container">
            © 2020 Copyright "Pavel Mekhnin"
            </div>
          </div>
        </footer>
)