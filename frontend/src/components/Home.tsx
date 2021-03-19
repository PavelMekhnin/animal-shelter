import React from "react";
import { Link } from "react-router-dom";

export const Home: React.FC = () => {

    return (
        <>
            <div className="row">
                <div className="home-block-header no-padding center-align col s12">
                    <div className="row">
                        <h2>Everyone deserve to have a family</h2>
                    </div>
                    <div className="row">
                        <h5>Lets make their life happy and they will never forget it</h5>
                    </div>
                    <div className="row">
                        <Link className="waves-effect waves-light btn orange" to="/search">
                            <i className="material-icons right">near_me</i>Find a shelter nearby</Link>
                    </div>
                </div>
            </div>
            <div className="row orange-text center">
            <h3>With us you can ...</h3>
            </div>
            <div className="home-block-body container valign-wrapper row">
                <div className="col s12 offset-l1 l10">
                    <div className="row">
                        <div className="col m4 s12">
                            <div className="center">
                                <i className="material-icons large promo-icon">favorite</i>
                                <h4>be caring</h4>
                                <p>Everyone can help to a shelter or take a pet home.</p>
                            </div>
                        </div>
                        <div className="col m4 s12">
                            <div className="center">
                                <i className="material-icons large promo-icon">people</i>
                                <h4>be in contact</h4>
                                <p>Communicate with the shelters and volunteers.</p>
                            </div>
                        </div>
                        <div className="col m4 s12">
                            <div className="center">
                                <i className="material-icons large promo-icon">announcement</i>
                                <h4>be aware</h4>
                                <p>See up-to date information about the shelters and animals needs.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}