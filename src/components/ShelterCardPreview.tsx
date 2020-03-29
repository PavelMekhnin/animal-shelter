import React from "react";
import { IVolunteerCard, IShelterCard, IShelterCardPreview } from "../interfaces/Interfaces";

type ShelterCardProps = {
    card: IShelterCardPreview
}

export const ShelterCardPreview: React.FC<ShelterCardProps> = (card) => {

    return (
        <div className="col s12">
            <div className="card-panel grey lighten-5 z-depth-1">
                <div className="row valign-wrapper">
                    <div className="col s2">
                        <img src={card.card.logo_url} alt="" className="circle responsive-img" />
                    </div>
                    <div className="col s10">
                        <span className="black-text">
                            {card.card.title}, Адрес: {card.card.addres}
                        </span>
                    </div>
                </div>
            </div>
        </div>
    )
}