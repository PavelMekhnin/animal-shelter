import React from "react";

export const Home: React.FC = () => {

    return (
        <>
            <div className="home-block-header no-padding center-align">
                <div className="row">
                    <h1>Everyone deserve to have a famaly</h1>
                </div>
                <div className="row">
                    <h5>Lets make their life happy.</h5>
                </div>
                <div className="row">
                    <a className="waves-effect waves-light btn orange">
                        <i className="material-icons right">near_me</i>Find a shelter nearby</a>
                </div>
            </div>
            <div className="home-block-body container valign-wrapper">
                <div className="row">
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">announcement</i>
                            <h4>Be aware</h4>
                            <p>See up-todate information about shelters and animals needs.</p>
                        </div>
                    </div>
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">announcement</i>
                            <h4>Be aware</h4>
                            <p>See up-todate information about shelters and animals needs.</p>
                        </div>
                    </div>
                    <div className="col s4">
                        <div className="center">
                            <i className="material-icons large promo-icon">announcement</i>
                            <h4>Be aware</h4>
                            <p>See up-todate information about shelters and animals needs.</p>
                        </div>
                    </div>
                </div>
            </div>
        </>
    )
}