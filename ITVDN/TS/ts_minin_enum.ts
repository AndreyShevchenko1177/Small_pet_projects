enum Membership {
    Simple,
    Standard,
    Premium
};

const membership = Membership.Standard;
console.log(membership); // 1

const membershipReverse = Membership[2]
console.log(membershipReverse); // Premium

enum SocialMedia {
    VK = 'Vkontakte',
    FB = 'FaceBook',
    INST = 'Instagram'
}

const social = SocialMedia.INST;
console.log(social); // INSTAGRAM
