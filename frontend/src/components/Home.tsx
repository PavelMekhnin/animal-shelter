import React from "react";
import { Link } from "react-router-dom";

export const Home: React.FC = () => {

    return (
        <>
            <div className="home-block-header no-padding center-align">
                <div className="row">
                    <h1>Everyone deserve to have a family</h1>
                </div>
                <div className="row">
                    <h5>Lets make their life happy and they will never forget it</h5>
                </div>
                <div className="row">
                    <Link className="waves-effect waves-light btn orange" to="/search">
                        <i className="material-icons right">near_me</i>Find a shelter nearby</Link>
                </div>
            </div>
            <div className="home-block-body container valign-wrapper">
                <div className="row">
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">favorite</i>
                            <h4>Be caring</h4>
                            <p>Everyone can become a curator or take pet home.</p>
                        </div>
                    </div>
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">people</i>
                            <h4>Be in contact</h4>
                            <p>Communicate with shelters and other volunteers.</p>
                        </div>
                    </div>
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">announcement</i>
                            <h4>Be aware</h4>
                            <p>See up-to date information about shelters and animals needs.</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}