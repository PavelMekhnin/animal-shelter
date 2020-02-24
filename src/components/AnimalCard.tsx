import React from "react";
import { VolunteerCardPreview } from "./VolunteerCardPreview";
import { IVolunteerCard } from "../interfaces/Interfaces";

export const AnimalCard: React.FC = () => {

    const volunteerCard: IVolunteerCard = {
        firstName: "Pavel",
        lastName: "Mekhnin",
        id: 1,
        img_url: "",
        phone: "+7 (913) 715 67 48"
    }
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
                    <h5>Info</h5>
                    <p>BIO</p>
                </div>
                <div className="row">
                    <h5>Volunteers</h5>
                    <VolunteerCardPreview card={volunteerCard} />
                    <VolunteerCardPreview card={volunteerCard} />
                    <VolunteerCardPreview card={volunteerCard} />
                </div>
                <div className="row">
                    <h5>Needs</h5>
                    
                </div>
            </div>
        </>
    )
}