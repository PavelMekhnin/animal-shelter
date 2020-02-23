import React from "react";
import { VolunteerCardPreview } from "./VolunteerCardPreview";

export const AnimalCard: React.FC = () => {

    return (
        <>
            <div className="col s3 grey lighten-5 center-align">
            <div className="row">
                    <img src="" />
                </div>
                <div className="row">
                    <h4>Огонек</h4>
                </div>
                <div className="row">
                    <h4>40 лет</h4>
                </div>
                <div className="row">
                    <h4>Буденовская</h4>
                </div>
            </div>
            <div className="col s9">
                <div className="row">
                    <VolunteerCardPreview />
                    <VolunteerCardPreview />
                    <VolunteerCardPreview />
                </div>
                <div className="row">
                    <p>BIO</p>
                </div>
            </div>
        </>
    )
}