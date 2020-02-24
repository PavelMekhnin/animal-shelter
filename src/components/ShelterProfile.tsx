import React from "react";
import { AnimalCardPreview } from "./AnimalCardPreview";
import { IAnimalCard } from "../interfaces/Interfaces";

export const ShelterProfile: React.FC = () => {
    const cards: IAnimalCard = {
        name: "Огонек",
        bio: "",
        description: "Один из самых старейших коней в возрасте 40 лет живет на пенсии в нашем приюте.",
        id: 1,
        img_url: "https://images.theconversation.com/files/250401/original/file-20181213-110249-1czg7z.jpg"
    }
    return (
        <>
            <div className="row">

            </div>
            <div className="row">
                <div className="col s3 grey lighten-5 center-align">
                    <img className="responsive-img circle" src="https://3.404content.com/1/CD/21/1202057187605349659/fullsize.jpg" alt="" />
                    <div className="row"><h5>Chance for life</h5></div>
                    <div className="row"><h6>Pets: 73</h6></div>
                    <div className="row"><h6>Contacts</h6></div>
                    <div className="row"><p>+ 7 (913) 715 67 48</p></div>
                    <div className="row"><p>mps_kz@mail.ru</p></div>
                </div>

                <div className="col s9">
                    <div className="raw">
                        <div className="col s4"><AnimalCardPreview card={cards} /></div>
                        <div className="col s4"><AnimalCardPreview card={cards} /></div>
                        <div className="col s4"><AnimalCardPreview card={cards} /></div>
                    </div>
                </div>

            </div>
        </>
    )
}