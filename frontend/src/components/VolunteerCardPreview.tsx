import React from "react";
import { IVolunteerCard } from "../interfaces/Interfaces";

type VolunteerCardProps = {
    card: IVolunteerCard
}

export const VolunteerCardPreview: React.FC<VolunteerCardProps> = (card) => {

    return (
        <div className="col s12 m8 l6">
            <div className="card-panel grey lighten-5 z-depth-1">
                <div className="row valign-wrapper">
                    <div className="col s2">
                        <img src={card.card.imgUrl} alt="" className="circle responsive-img" />
                    </div>
                    <div className="col s10">
                        <span className="black-text">
                            {card.card.firstName}, contacts: {card.card.phone}
              </span>
                    </div>
                </div>
            </div>
        </div>
    )
}